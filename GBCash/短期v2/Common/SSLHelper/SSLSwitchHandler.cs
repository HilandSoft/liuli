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
	/// ���ýڵ�section����ɽṹ���£�
	///     <sslSwitchPaths ControlMode="AllowOther" DeployMode="On">
	///         <file value="~/**/**.aspx"></file>
	///         <path value="~/**/"></path>
	///     </sslSwitchPaths>
	///     1.sslSwitchPaths��DeployMode�ļ���ֵ
	///         On ���Ը������������ʹ��SSL(ȱʡ)
	///         RemoteOnly ������Զ�̿ͻ�������ʹ��SSL ��վ���𵽷�������ʹ�ô�����
	///         LocalOnly ���ص���ʱʹ��
	///         Off SSL������
	///     2.sslSwitchPaths��ControlMode�ļ���ֵ
	///         OnlyThus �������������Ĳ���ʹ��ssl,�������ֲ�����ssl
	///         AllowOther ������������ʹ��ssl(��ɲ�ʹ��)(ȱʡ)
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