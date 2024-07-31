# Estágio de construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia o arquivo .csproj e restaura as dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o restante do código e compila
COPY . ./
RUN dotnet publish -c Release -o out

FROM build-env as migrations
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
ENTRYPOINT dotnet-ef database update

# Estágio de produção
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "TaskManagerAPI.dll"]
