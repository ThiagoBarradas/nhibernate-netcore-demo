FROM microsoft/dotnet:2.1-sdk AS builder

WORKDIR /source

# Copy source files
COPY ./ ./

# Build application
RUN dotnet restore
RUN dotnet publish -c release --output /app/

# RUNTIME IMAGE
FROM microsoft/dotnet:2.1-runtime

# Default Environment
ENV ASPNETCORE_ENVIRONMENT="Development"

# Args
COPY --from=builder /app /app

# Run application
WORKDIR /app
RUN ls
ENTRYPOINT [ "dotnet", "NHibernate.NETCore.Demo.dll" ]