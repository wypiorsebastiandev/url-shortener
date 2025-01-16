# dometrain-url-shortener
Let's Build It: Url Shortener Course


## Infrastructure as Code

### Download Azure CLI
https://learn.microsoft.com/en-us/cli/azure/

### Log in into Azure
```bash
az login
```

### Create Resource Group

```bash
az group create --name swpr-urlshortener-dev --location westeurope
```

### Deploy Bicep

### What if
```bash
az deployment group what-if --resource-group swpr-urlshortener-dev --template-file infrastructure/main.bicep
```

### Deploy
```bash
az deployment group create --resource-group swpr-urlshortener-dev --template-file infrastructure/main.bicep
```

### Create User for GH Actions

```bash
az ad sp create-for-rbac --name "GitHub-Actions-SP" \
                         --role contributor \
                         --scopes /subscriptions/89518450-6f9c-4039-8834-c5bab3ad3e92 \
                         --sdk-auth
```

#### Configure a federated identity credential on an app

https://learn.microsoft.com/en-gb/entra/workload-id/workload-identity-federation-create-trust?pivots=identity-wif-apps-methods-azp#configure-a-federated-identity-credential-on-an-app

## Get Azure Publish Profile

```bash
az webapp deployment list-publishing-profiles --name api-piza2nvlxc5jg --resource-group dometrain-urlshortener-dev --xml
```