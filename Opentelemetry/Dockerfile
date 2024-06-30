FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY MySolution.sln .
COPY API/API.csproj ./API/API.csproj 
COPY Appication/Appication.csproj ./Appication/Appication.csproj
COPY Domain/Domain.csproj ./Domain/Domain.csproj
COPY Infrastructure/Infrastructure.csproj ./Infrastructure/Infrastructure.csproj

RUN dotnet restore ./API/API.csproj 

COPY . .

WORKDIR /app/API
RUN dotnet publish -c Release -o /app/publish

# สร้าง runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_ENVIRONMENT=DockerDev
ENV ASPNETCORE_URLS=http://+:5001
EXPOSE 5001

ENTRYPOINT ["dotnet", "API.dll"]

# # ใช้ .NET SDK image
# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# # ตั้งค่าไดเรกทอรีการทำงาน
# WORKDIR /app

# # คัดลอกไฟล์ .csproj และคืนค่าขึ้นอยู่ (restore dependencies)
# COPY *.csproj ./
# RUN dotnet restore

# # คัดลอกโค้ดที่เหลือและสร้าง (build) โค้ด
# COPY . ./
# RUN dotnet publish -c Release -o out

# # สร้าง runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:6.0
# WORKDIR /app
# COPY --from=build-env /app/out .

# # เปิดพอร์ตที่แอปพลิเคชันจะรัน
# EXPOSE 5001

# # ตั้งค่า entry point
# ENTRYPOINT ["dotnet", "API.dll"]