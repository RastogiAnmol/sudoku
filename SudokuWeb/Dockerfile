FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["SudokuWeb/SudokuWeb.csproj", "SudokuWeb/"]
RUN dotnet restore "SudokuWeb/SudokuWeb.csproj"
COPY . .
WORKDIR "/src/SudokuWeb"
RUN dotnet build "SudokuWeb.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SudokuWeb.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SudokuWeb.dll"]