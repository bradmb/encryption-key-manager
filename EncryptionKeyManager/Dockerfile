FROM microsoft/aspnetcore:2.0

ARG source
ARG allowed_hosts
ARG encryption_key

WORKDIR /app

EXPOSE 80

COPY ${source:-obj/Docker/publish} .

ENV ASPNETCORE_ENVIRONMENT="Production"
ENV APP_ENCRYPTION_KEY=$encryption_key
ENV APP_ALLOWED_HOSTS=$allowed_hosts

ENTRYPOINT ["dotnet", "EncryptionKeyManager.dll"]