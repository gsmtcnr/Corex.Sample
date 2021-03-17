#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Corex.Sample.Presentation.ConsoleApp/Corex.Sample.Presentation.ConsoleApp.csproj", "Corex.Sample.Presentation.ConsoleApp/"]
COPY ["Corex.Sample.Serializer.Derived.NewtonSerializer/Corex.Sample.Serializer.Derived.NewtonSerializer.csproj", "Corex.Sample.Serializer.Derived.NewtonSerializer/"]
COPY ["Corex.Sample.Serializer.Inftrastructure/Corex.Sample.Serializer.Inftrastructure.csproj", "Corex.Sample.Serializer.Inftrastructure/"]
COPY ["Corex.Sample.Caching.Derived.MemoryCaching/Corex.Sample.Caching.Derived.MemoryCaching.csproj", "Corex.Sample.Caching.Derived.MemoryCaching/"]
COPY ["Corex.Sample.Caching.Infrastructure/Corex.Sample.Caching.Infrastructure.csproj", "Corex.Sample.Caching.Infrastructure/"]
COPY ["Corex.Sample.Core.Infrastructure/Corex.Sample.Core.Infrastructure.csproj", "Corex.Sample.Core.Infrastructure/"]
COPY ["Corex.Sample.Model.Infrastructure/Corex.Sample.Model.Infrastructure.csproj", "Corex.Sample.Model.Infrastructure/"]
COPY ["Corex.Sample.EmailSender.Derived.SMTPEmailSender/Corex.Sample.EmailSender.Derived.SMTPEmailSender.csproj", "Corex.Sample.EmailSender.Derived.SMTPEmailSender/"]
COPY ["Corex.Sample.EmailSender.Inftrastructure/Corex.Sample.EmailSender.Inftrastructure.csproj", "Corex.Sample.EmailSender.Inftrastructure/"]
COPY ["Corex.Sample.Mapper.Derived.MapsterMapper/Corex.Sample.Mapper.Derived.MapsterMapper.csproj", "Corex.Sample.Mapper.Derived.MapsterMapper/"]
COPY ["Corex.Sample.Mapper.Infrastructure/Corex.Sample.Mapper.Infrastructure.csproj", "Corex.Sample.Mapper.Infrastructure/"]
COPY ["Corex.Sample.Operation.Manager/Corex.Sample.Operation.Manager.csproj", "Corex.Sample.Operation.Manager/"]
COPY ["Corex.Sample.Operation.DataOperation/Corex.Sample.Operation.DataOperation.csproj", "Corex.Sample.Operation.DataOperation/"]
COPY ["Corex.Sample.Model.ViewModel/Corex.Sample.Model.ViewModel.csproj", "Corex.Sample.Model.ViewModel/"]
COPY ["Corex.Sample.Data.Infrastructure/Corex.Sample.Data.Infrastructure.csproj", "Corex.Sample.Data.Infrastructure/"]
COPY ["Corex.Sample.Model.EntityModel/Corex.Sample.Model.EntityModel.csproj", "Corex.Sample.Model.EntityModel/"]
COPY ["Corex.Sample.Operation.MailOperation/Corex.Sample.Operation.MailOperation.csproj", "Corex.Sample.Operation.MailOperation/"]
COPY ["Corex.Sample.Model.MailModel/Corex.Sample.Model.MailModel.csproj", "Corex.Sample.Model.MailModel/"]
COPY ["Corex.Sample.Model.DtoModel/Corex.Sample.Model.DtoModel.csproj", "Corex.Sample.Model.DtoModel/"]
COPY ["Corex.Sample.Operation.ValidationOperation/Corex.Sample.Operation.ValidationOperation.csproj", "Corex.Sample.Operation.ValidationOperation/"]
COPY ["Corex.Sample.Validation.DtoValidation/Corex.Sample.Validation.DtoValidation.csproj", "Corex.Sample.Validation.DtoValidation/"]
COPY ["Corex.Sample.Validation.InputValidation/Corex.Sample.Validation.InputValidation.csproj", "Corex.Sample.Validation.InputValidation/"]
COPY ["Corex.Sample.Operation.BusinessOperation/Corex.Sample.Operation.BusinessOperation.csproj", "Corex.Sample.Operation.BusinessOperation/"]
COPY ["Corex.Sample.Encryptor.Infrastructure/Corex.Sample.Encryptor.Infrastructure.csproj", "Corex.Sample.Encryptor.Infrastructure/"]
COPY ["Corex.Sample.Data.Derived.EFSQL/Corex.Sample.Data.Derived.EFSQL.csproj", "Corex.Sample.Data.Derived.EFSQL/"]
COPY ["Corex.Sample.Encryptor.Derived.SHAEncryptor/Corex.Sample.Encryptor.Derived.SHAEncryptor.csproj", "Corex.Sample.Encryptor.Derived.SHAEncryptor/"]
RUN dotnet restore "Corex.Sample.Presentation.ConsoleApp/Corex.Sample.Presentation.ConsoleApp.csproj"
COPY . .
WORKDIR "/src/Corex.Sample.Presentation.ConsoleApp"
RUN dotnet build "Corex.Sample.Presentation.ConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Corex.Sample.Presentation.ConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Corex.Sample.Presentation.ConsoleApp.dll"]