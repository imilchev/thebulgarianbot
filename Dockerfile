# Cannot build on armv7
FROM mcr.microsoft.com/dotnet/sdk:7.0-bullseye-slim-arm64v8 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY TheBulgarianBot.Application/TheBulgarianBot.Application.csproj ./TheBulgarianBot.Application/
COPY TheBulgarianBot.Business/TheBulgarianBot.Business.csproj ./TheBulgarianBot.Business/
RUN dotnet restore

# copy everything else and build app
COPY TheBulgarianBot.Application/. ./TheBulgarianBot.Application/
COPY TheBulgarianBot.Business/. ./TheBulgarianBot.Business/
WORKDIR /app/TheBulgarianBot.Application
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/runtime:7.0-bullseye-slim-arm64v8 AS runtime

RUN apt update && apt install libgdiplus -y
# RUN apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
# RUN echo "deb https://download.mono-project.com/repo/ubuntu stable-bionic main" | tee /etc/apt/sources.list.d/mono-official-stable.list
# RUN apt update
# RUN apt install libjpeg8 libgdiplus -y

ENV ASPNETCORE_ENVIRONMENT "Development"

WORKDIR /app
COPY --from=build /app/TheBulgarianBot.Application/out ./

COPY images/. ./images

ENTRYPOINT ["dotnet", "TheBulgarianBot.Application.dll"]
