<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="Portfolio.AzureService" generation="1" functional="0" release="0" Id="34f0d357-655e-4a8b-aaff-a3a1c9a8e1bb" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="Portfolio.AzureServiceGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="Portfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" protocol="tcp">
          <inToChannel>
            <lBChannelMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/LB:Portfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="Certificate|Portfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" defaultValue="">
          <maps>
            <mapMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/MapCertificate|Portfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
          </maps>
        </aCS>
        <aCS name="Portfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/MapPortfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="Portfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" defaultValue="">
          <maps>
            <mapMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/MapPortfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" />
          </maps>
        </aCS>
        <aCS name="Portfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" defaultValue="">
          <maps>
            <mapMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/MapPortfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" />
          </maps>
        </aCS>
        <aCS name="Portfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" defaultValue="">
          <maps>
            <mapMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/MapPortfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" />
          </maps>
        </aCS>
        <aCS name="Portfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" defaultValue="">
          <maps>
            <mapMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/MapPortfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" />
          </maps>
        </aCS>
        <aCS name="Portfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" defaultValue="">
          <maps>
            <mapMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/MapPortfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" />
          </maps>
        </aCS>
        <aCS name="Portfolio.AzureJobRole:PortfolioConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/MapPortfolio.AzureJobRole:PortfolioConnectionString" />
          </maps>
        </aCS>
        <aCS name="Portfolio.AzureJobRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/MapPortfolio.AzureJobRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:Portfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput">
          <toPorts>
            <inPortMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/Portfolio.AzureJobRole/Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </toPorts>
        </lBChannel>
        <sFSwitchChannel name="SW:Portfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp">
          <toPorts>
            <inPortMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/Portfolio.AzureJobRole/Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" />
          </toPorts>
        </sFSwitchChannel>
      </channels>
      <maps>
        <map name="MapCertificate|Portfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" kind="Identity">
          <certificate>
            <certificateMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/Portfolio.AzureJobRole/Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
          </certificate>
        </map>
        <map name="MapPortfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/Portfolio.AzureJobRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapPortfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" kind="Identity">
          <setting>
            <aCSMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/Portfolio.AzureJobRole/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" />
          </setting>
        </map>
        <map name="MapPortfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" kind="Identity">
          <setting>
            <aCSMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/Portfolio.AzureJobRole/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" />
          </setting>
        </map>
        <map name="MapPortfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" kind="Identity">
          <setting>
            <aCSMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/Portfolio.AzureJobRole/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" />
          </setting>
        </map>
        <map name="MapPortfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" kind="Identity">
          <setting>
            <aCSMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/Portfolio.AzureJobRole/Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" />
          </setting>
        </map>
        <map name="MapPortfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" kind="Identity">
          <setting>
            <aCSMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/Portfolio.AzureJobRole/Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" />
          </setting>
        </map>
        <map name="MapPortfolio.AzureJobRole:PortfolioConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/Portfolio.AzureJobRole/PortfolioConnectionString" />
          </setting>
        </map>
        <map name="MapPortfolio.AzureJobRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/Portfolio.AzureJobRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="Portfolio.AzureJobRole" generation="1" functional="0" release="0" software="C:\Projects\Portfolio\Portfolio.AzureService\csx\Release\roles\Portfolio.AzureJobRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaWorkerHost.exe " memIndex="1792" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" protocol="tcp" />
              <inPort name="Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" protocol="tcp" portRanges="3389" />
              <outPort name="Portfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/SW:Portfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" />
                </outToChannel>
              </outPort>
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" defaultValue="" />
              <aCS name="PortfolioConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;Portfolio.AzureJobRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;Portfolio.AzureJobRole&quot;&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
            <storedcertificates>
              <storedCertificate name="Stored0Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" certificateStore="My" certificateLocation="System">
                <certificate>
                  <certificateMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/Portfolio.AzureJobRole/Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
                </certificate>
              </storedCertificate>
            </storedcertificates>
            <certificates>
              <certificate name="Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
            </certificates>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/Portfolio.AzureJobRoleInstances" />
            <sCSPolicyFaultDomainMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/Portfolio.AzureJobRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="Portfolio.AzureJobRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="Portfolio.AzureJobRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="7cf85ad4-1a1d-4746-8e4b-0a5da9626064" ref="Microsoft.RedDog.Contract\ServiceContract\Portfolio.AzureServiceContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="a2d3a4d7-0f56-47ba-a7ca-7209dbfd7acb" ref="Microsoft.RedDog.Contract\Interface\Portfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/Portfolio.AzureService/Portfolio.AzureServiceGroup/Portfolio.AzureJobRole:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>