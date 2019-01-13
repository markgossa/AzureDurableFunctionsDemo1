# Create resource group
resource "azurerm_resource_group" "resourceGroup1" {
  name     = "${var.ResourceGroupName}"
  location = "${var.ResourceGroupLocation}"
}

# Create a storage account
resource "azurerm_storage_account" "storageAccount1" {
  name                     = "${var.StorageAccountName}"
  resource_group_name      = "${azurerm_resource_group.resourceGroup1.name}"
  location                 = "${azurerm_resource_group.resourceGroup1.location}"
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_app_service_plan" "appServicePlan1" {
  name                = "${var.AppServicePlanName}"
  location            = "${azurerm_resource_group.resourceGroup1.location}"
  resource_group_name = "${azurerm_resource_group.resourceGroup1.name}"
  kind                = "FunctionApp"

  sku {
    tier = "Dynamic"
    size = "Y1"
  }
}

resource "azurerm_function_app" "functionApp1" {
  name                      = "${var.FunctionAppName}"
  location                  = "${azurerm_resource_group.resourceGroup1.location}"
  resource_group_name       = "${azurerm_resource_group.resourceGroup1.name}"
  app_service_plan_id       = "${azurerm_app_service_plan.appServicePlan1.id}"
  storage_connection_string = "${azurerm_storage_account.storageAccount1.primary_connection_string}"
}
