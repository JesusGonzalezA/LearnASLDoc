dotnet user-secrets init
# For Windows users
type .\secrets.json | dotnet user-secrets set

# For mac/linux users
cat ./secrets.json | dotnet user-secrets set