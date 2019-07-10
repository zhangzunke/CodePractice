FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["K8sDemo/K8sDemo.csproj", "K8sDemo/"]
RUN dotnet restore "K8sDemo/K8sDemo.csproj"
COPY . .
WORKDIR "/src/K8sDemo"
RUN dotnet build "K8sDemo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "K8sDemo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "K8sDemo.dll"]