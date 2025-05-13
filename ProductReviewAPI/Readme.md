
# Product Review API

Este microservicio proporciona una API para analizar reseñas de productos. Utiliza una IA simulada que detecta el sentimiento, calcula la legibilidad del texto y sugiere mejoras en la reseña.

## 🚀 Características

- Análisis de sentimiento (positivo, negativo, neutral)
- Cálculo de legibilidad
- Sugerencias automáticas para mejorar el texto
- Arquitectura limpia y modular con soporte para futuras integraciones con IA reales
- Pruebas unitarias e integración listas
- Listo para Docker
- Preparado para integración continua (CI)

## 🧱 Estructura del Proyecto

```
ProductReviewAPI/
│
├── Controllers/
│   └── ReviewController.cs
├── Factory/
│   └── AIProviderFactory.cs
├── Filters/
│   └── ValidateModelAttribute.cs
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
├── Interfaces/
│   └── IReviewService.cs
│   └── IAIProvider.cs
├── Models/
│   ├── ReviewRequest.cs
│   └── ReviewResponse.cs
├── Services/
│   └── ReviewService.cs
│   └── SimulatedAIProvider.cs
│   └── ExternalAIProvider.cs
├── Helpers/
│   └── ReadabilityHelper.cs
│   └── SentimentHelper.cs
│   └── SuggestionHelper.cs
├── ProductReviewAPI.http
├── Program.cs
├── appsettings.json
├── Dockerfile
├── docker-compose.yml
└── README.md
```
ProductReviewAPI.Test/
│
├── Controllers/
│   └── ReviewControllerTests.cs
├── Helpers/
│   └── ReadabilityHelperTests.cs
│   └── SentimentHelperTests.cs
│   └── SuggestionHelperTests.cs
├── Middleware/
│   └── ExceptionHandlingMiddlewareTests.cs
├── Services/
│   └── ReviewServiceTests.cs
│   └── SimulatedAIProviderTests.cs

## 🛠 Configuración

1. Clona el repositorio:
```bash
git clone https://github.com/MarioHdzFls/ProductReviewAPI
cd ProductReviewAPI
```

2. Ejecuta el proyecto con Visual Studio 2022 o desde CLI:
```bash
dotnet run
```

## 🧪 Ejecución de Pruebas

```bash
dotnet test
```

## 🐳 Docker

### Requisitos

- Docker Desktop instalado y en ejecución.

### Comandos

```bash
docker build -t productreviewapi .
docker run -p 8080:80 productreviewapi
```

## 🧠 Lógica de IA Simulada

La lógica de IA está implementada en `SimulatedAIProvider.cs`, pero el sistema es extensible para conectarse con servicios externos como OpenAI, Azure Cognitive Services, etc., mediante la interfaz `IAIProvider`.

## ✅ Ejemplo de Solicitud HTTP

```
POST /review
Content-Type: application/json

{
  "reviewText": "Este producto es excelente, me encantó desde que lo compré."
}
```

## 📦 Herramientas de IA utilizadas

- GitHub Copilot: Para autocompletar código repetitivo.
- ChatGPT: Para diseño de arquitectura y sugerencias de pruebas.

## 📄 Licencia

MIT
