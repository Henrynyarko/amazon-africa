param location string = resourceGroup().location
param appServiceName string = 'amazonafrica-dev-api'
param appServicePlanName string = 'amazonafrica-dev-plan'
param postgresServerName string = 'amazonafrica-dev-db'
param postgresAdmin string = 'dbadmin'
@secure()
param postgresPassword string

resource appServicePlan 'Microsoft.Web/serverfarms@2022-03-01' = {
  name: appServicePlanName
  location: location
  sku: {
    name: 'B1'
    tier: 'Basic'
    size: 'B1'
  }
}

resource appService 'Microsoft.Web/sites@2022-03-01' = {
  name: appServiceName
  location: location
  kind: 'app'
  properties: {
    serverFarmId: appServicePlan.id
    httpsOnly: true
  }
}

resource postgresServer 'Microsoft.DBforPostgreSQL/servers@2022-12-01' = {
  name: postgresServerName
  location: location
  sku: {
    name: 'B_Gen5_1'
    tier: 'Basic'
    capacity: 1
    family: 'Gen5'
  }
  properties: {
    administratorLogin: postgresAdmin
    administratorLoginPassword: postgresPassword
    version: '14'
    sslEnforcement: 'Enabled'
    minimalTlsVersion: 'TLS1_2'
    publicNetworkAccess: 'Enabled'
  }
}

resource postgresDb 'Microsoft.DBforPostgreSQL/servers/databases@2022-12-01' = {
  name: '${postgresServer.name}/amazonafrica'
  properties: {}
  dependsOn: [
    postgresServer
  ]
}

output appServiceUrl string = appService.properties.defaultHostName
output postgresServerFqdn string = postgresServer.properties.fullyQualifiedDomainName
