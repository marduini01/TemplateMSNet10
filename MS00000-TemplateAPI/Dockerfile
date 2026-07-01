FROM instance-quay-quay-registry.apps.ocps.sviluppo.inps.it/global/dotnet-100-runtime-datapower AS base
USER 1001

ENV LD_LIBRARY_PATH=/app/clidriver/lib/
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

FROM base AS final
USER 1001
WORKDIR /app
COPY ./publish .
RUN find /app/
ENTRYPOINT ["dotnet", "MS00000_TemplateAPI.dll"]
HEALTHCHECK NONE 