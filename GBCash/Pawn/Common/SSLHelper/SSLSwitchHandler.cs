using System;
using System.Configuration;
using System.Xml;
using YingNet.Common;

namespace YingNet.Common.SSLHelper
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// 配置节点section的组成结构如下：
	///     <sslSwitchPaths ControlMode="AllowOther" DeployMode="On">
	///         <file value="~/**/**.aspx"></file>
	///         <path value="~/**/"></path>
	///     </sslSwitchPaths>
	///     1.sslSwitchPaths中DeployMode的几个值
	///         On 来自各个方向的请求使用SSL(缺省)
	///         RemoteOnly 来自于远程客户的请求使用SSL 网站部署到服务器上使用此属性
	///         LocalOnly 本地调试时使用
	///         Off SSL不可用
	///     2.sslSwitchPaths中ControlMode的几个值
	///         OnlyThus 仅本部分声明的部分使用ssl,其他部分不是用ssl
	///         AllowOther 允许其他部分使用ssl(亦可不使用)(缺省)
	/// </remarks>
	public class SSLSwitchHandler : IConfigurationSectionHandler
	{
		public object Create(object parent, object configContext, System.Xml.XmlNode section)
		{
			SSLSwitchConfig config = new SSLSwitchConfig();
            
			XmlAttribute controlModeAttribute = section.Attributes["ControlMode"];
			if (controlModeAttribute != null && StringHelper.IsNullOrEmpty( controlModeAttribute.Value)==false)
			{
				config.ControlMode = (ControlModes)Enum.Parse(typeof(ControlModes), controlModeAttribute.Value); //Converter.ToEnum<ControlModes>(controlModeAttribute.Value);
			}

			XmlAttribute deployModeAttribute = section.Attributes["DeployMode"];
			if (deployModeAttribute != null && StringHelper.IsNullOrEmpty(deployModeAttribute.Value) == false)
			{
				config.DeployMode = (DeployModes)Enum.Parse(typeof(DeployModes), deployModeAttribute.Value);//Converter.ToEnum<DeployModes>(deployModeAttribute.Value);
			}
            
			foreach (XmlNode node in section.ChildNodes)
			{
				XmlAttribute valueAttribute = node.Attributes["value"];
				if (valueAttribute != null)
				{
					string info = valueAttribute.Value;
					if (StringHelper.IsNullOrEmpty(info) == false)
					{
						config.SSLList.Add(info);
					}
				}
			}

			return config;
		}
	}
}