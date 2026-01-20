param location string = resourceGroup().location
param appServiceName string = 'amazonafrica-prod-api'
param appServicePlanName string = 'amazonafrica-prod-plan'
param postgresServerName string = 'amazonafrica-prod-db'
param postgresAdmin string = 'dbadmin'
@secure()
param postgresPassword string

// App Service Plan
resource appServicePlan 'Microsoft.Web/serverfarms@2022-03-01' = {
  name: appServicePlanName
  location: location
  sku: {
    name: 'S1'  // Standard for production
    tier: 'Standard'
    size: 'S1'
  }
}

// App Service
resource appService 'Microsoft.Web/sites@2022-03-01' = {
  name: appServiceName
  location: location
  kind: 'app'
  properties: {
    serverFarmId: appServicePlan.id
    httpsOnly: true
  }
}

// PostgreSQL Server (private network for production)
resource postgresServer 'Microsoft.DBforPostgreSQL/servers@2022-12-01' = {
  name: postgresServerName
  location: location
  sku: {
    name: 'B_Gen5_2'
    tier: 'Basic'
    capacity: 2
    family: 'Gen5'
  }
  properties: {
    administratorLogin: postgresAdmin
    administratorLoginPassword: postgresPassword
    version: '14'
    sslEnforcement: 'Enabled'
    minimalTlsVersion: 'TLS1_2'
    publicNetworkAccess: 'Disabled' // private for prod
  }
}

// PostgreSQL Database
resource postgresDb 'Microsoft.DBforPostgreSQL/servers/databases@2022-12-01' = {
  name: '${postgresServer.name}/amazonafrica'
  properties: {}
  dependsOn: [
    postgresServer
  ]
}

// Outputs
output appServiceUrl string = appService.properties.defaultHostName
output postgresServerFqdn string = postgresServer.properties.fullyQualifiedDomainName
