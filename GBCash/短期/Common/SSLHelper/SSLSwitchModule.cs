using System;
using System.Configuration;
using System.Web;
using System.Web.UI;

namespace YingNet.Common.SSLHelper
{
	/// <summary>
	/// 根据需求进行http和https之间进行切换
	/// </summary>
	public class SSLSwitchModule : IHttpModule
	{
		private HttpApplication context;
		public void Dispose()
		{
		}

		public void Init(HttpApplication context)
		{
			this.context = context;
			context.BeginRequest += new EventHandler(context_BeginRequest);
		}

		void context_BeginRequest(object sender, EventArgs e)
		{
			SSLSwitchConfig config = ConfigurationSettings.GetConfig("sslSwitchPaths") as SSLSwitchConfig;
			if (config != null && config.DeployMode != DeployModes.Off)
			{
				string currentVirtualPath = HttpContext.Current.Request.Url.AbsolutePath.ToLower();
				string basePath= HttpContext.Current.Request.ApplicationPath;
				if(basePath.EndsWith("/")==false)
				{
					basePath= basePath + "/";
				}

				if(currentVirtualPath.StartsWith(basePath))
				{
					currentVirtualPath= currentVirtualPath.Substring(basePath.Length);
				}
					
				bool isContaint = config.IsContaint(currentVirtualPath);

				bool needJumpForSSLControl = isContaint;
				bool needJumpForCommonControl = false;

				if (config.ControlMode == ControlModes.OnlyThus && isContaint == false)
				{
					needJumpForCommonControl = true;
				}


				bool needJumpForDeploy = false;
				switch (config.DeployMode)
				{
					case DeployModes.RemoteOnly:
						if (RequestHelper.IsRemoteServer == true)
						{
							needJumpForDeploy = true;
						}
						break;
					case DeployModes.LocalOnly:
						if (RequestHelper.IsLocalServer == true)
						{
							needJumpForDeploy = true;
						}
						break;
					case DeployModes.On:
					default:
						needJumpForDeploy = true;
						break;
				}

				string currentScheme = HttpContext.Current.Request.Url.Scheme.ToLower();

				//根据需要将被控制的页面使用安全请求模式
				if (needJumpForDeploy == true && needJumpForSSLControl == true)
				{

					if (currentScheme == "http")
					{
						string newPath = "https://" + RequestHelper.GetOriginalUrlWithoutSchemeHeader();
						HttpContext.Current.Response.Redirect(newPath);
					}
				}

				//根据需要将未控制的页面使用普通请求模式
				if (needJumpForCommonControl == true)
				{
					if (currentScheme == "https")
					{
						string newPath = "http://" + RequestHelper.GetOriginalUrlWithoutSchemeHeader();
						HttpContext.Current.Response.Redirect(newPath);
					}
				}
			}
		}
	}
}
