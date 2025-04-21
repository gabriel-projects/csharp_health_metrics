# 🚀 ASP.NET Core Project - Observable, Testable, and Scalable with YARP, Prometheus, and Grafana

This project aims to be a solid foundation for ASP.NET Core applications focusing on:
- ✅ Observability
- ✅ Resilience
- ✅ Testability
- ✅ Clean and Scalable Architecture
- ✅ Reverse Proxy with Load Balancer via YARP

---

## 📦 Technologies and Tools

- ASP.NET Core 9
- Docker + Docker Compose
- SQL Server
- Prometheus
- Grafana
- YARP (Yet Another Reverse Proxy)
- Serilog
- Polly
- OpenTelemetry (optional)
- Testcontainers (optional)

---

## 🧭 Technical Expansion Roadmap

### 1. 🔍 Professional Observability

| Item | Status |
|------|--------|
| Health Checks (Liveness, Readiness) | ✅ |
| HTTP and Domain Metrics (Prometheus) | ✅ |
| Grafana Dashboards | ✅ |
| Domain Metrics Exposure (e.g., processed tasks) | 🔄 |
| Distributed Tracing with OpenTelemetry | 🔄 |
| Correlation ID Middleware | 🔄 |

---

### 2. 📄 Logging and Distributed Tracing

| Item | Status |
|------|--------|
| Serilog (Console + File) | ✅ |
| Structured Logging with Context (TraceId, UserId, etc) | 🔄 |
| Log Shipping to Loki / Elasticsearch | 🔄 |
| Application Insights (optional) | 🔄 |
| Request/Response Logging Middleware | 🔄 |

---

### 3. 🧪 Automated Testing and Resilience

| Item | Status |
|------|--------|
| Health Check Tests | ✅ |
| Integration Tests with Testcontainers | 🔄 |
| Retry, Timeout, Circuit Breaker with Polly | 🔄 |
| Chaos Testing (failure simulation) | 🔄 |
| Load Testing with NBomber / k6 | 🔄 |

---

### 4. 🔔 Monitoring and Alerts

| Item | Status |
|------|--------|
| Custom Grafana Dashboards | ✅ |
| Configured Alerts (e.g., 5xx errors ↑, failing health checks) | 🔄 |
| YARP Monitoring (backend latency, errors) | 🔄 |
| Alertmanager + Slack/Discord/Teams Integration | 🔄 |

---

### 5. 🧱 Scalable Architecture

| Item | Status |
|------|--------|
| Modular Clean Architecture (Domain, Infra, API, Worker) | ✅ |
| CQRS with MediatR | 🔄 |
| BackgroundService with Queue (RabbitMQ or channel) | 🔄 |
| Event Publishing with Domain Events | 🔄 |
| Modularization via Class Libraries | ✅ |
| Use of ValueObjects and Aggregates (DDD) | 🔄 |

---

### 6. 🌐 YARP + Docker – Reverse Proxy with Load Balancer

| Item | Status |
|------|--------|
| YARP Service via Docker | ✅ |
| Load Balancing Between Multiple API Instances | ✅ |
| Routing by Path/Header/Host | 🔄 |
| Sticky Sessions or Round-robin | 🔄 |
| Prometheus Middleware in YARP | 🔄 |
| Proxy Metrics in Grafana | 🔄 |

---

## 📈 Next Steps

- [ ] Configure OpenTelemetry with spans between services
- [ ] Upload logs to Loki and visualize in Grafana Logs
- [ ] Implement task service with CQRS + Worker
- [ ] Add integration tests with Testcontainers
- [ ] Add hybrid cache (Memory + Redis)
- [ ] Automate deployment with GitHub Actions + Terraform

---

## 🌐 Contact

---
