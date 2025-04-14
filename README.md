# 🚀 Projeto ASP.NET Core - Observável, Testável e Escalável com YARP, Prometheus e Grafana

Este projeto tem como objetivo ser uma base sólida para aplicações ASP.NET Core com foco em:
- ✅ Observabilidade
- ✅ Resiliência
- ✅ Testabilidade
- ✅ Arquitetura Limpa e Escalável
- ✅ Proxy reverso com Load Balancer via YARP

---

## 📦 Tecnologias e Ferramentas

- ASP.NET Core 9
- Docker + Docker Compose
- SQL Server
- Prometheus
- Grafana
- YARP (Yet Another Reverse Proxy)
- Serilog
- Polly
- OpenTelemetry (opcional)
- Testcontainers (opcional)

---

## 🧭 Roadmap Técnico de Expansão

### 1. 🔍 Observabilidade Profissional

| Item | Status |
|------|--------|
| Health Checks (Liveness, Readiness) | ✅ |
| Métricas HTTP e domínio (Prometheus) | ✅ |
| Dashboards no Grafana | ✅ |
| Exposição de métricas de domínio (ex: tarefas processadas) | 🔄 |
| Tracing distribuído com OpenTelemetry | 🔄 |
| Middleware de Correlation ID | 🔄 |

---

### 2. 📄 Logging e Tracing distribuído

| Item | Status |
|------|--------|
| Serilog (Console + Arquivo) | ✅ |
| Logging estruturado com contexto (TraceId, UserId, etc) | 🔄 |
| Envio de logs para Loki / Elasticsearch | 🔄 |
| Application Insights (opcional) | 🔄 |
| Middleware de logging de request/response | 🔄 |

---

### 3. 🧪 Testes Automatizados e Resiliência

| Item | Status |
|------|--------|
| Testes de Health Check | ✅ |
| Testes de integração com Testcontainers | 🔄 |
| Retry, Timeout, Circuit Breaker com Polly | 🔄 |
| Chaos Testing (simulação de falhas) | 🔄 |
| Load Testing com NBomber / k6 | 🔄 |

---

### 4. 🔔 Monitoramento e Alertas

| Item | Status |
|------|--------|
| Dashboards customizados no Grafana | ✅ |
| Alertas configurados (ex: erro 5xx ↑, health check falhando) | 🔄 |
| Monitoramento do YARP (latência por backend, erros) | 🔄 |
| Alertmanager + integração com Slack/Discord/Teams | 🔄 |

---

### 5. 🧱 Arquitetura Escalável

| Item | Status |
|------|--------|
| Clean Architecture modular (Domain, Infra, API, Worker) | ✅ |
| CQRS com MediatR | 🔄 |
| BackgroundService com fila (RabbitMQ ou channel) | 🔄 |
| Publicação de eventos com Domain Events | 🔄 |
| Modularização via Class Libraries | ✅ |
| Uso de ValueObjects e Aggregates (DDD) | 🔄 |

---

### 6. 🌐 YARP + Docker – Proxy Reverso com Load Balancer

| Item | Status |
|------|--------|
| Serviço YARP via Docker | ✅ |
| Balanceamento entre múltiplas instâncias da API | ✅ |
| Roteamento por path/header/host | 🔄 |
| Sticky sessions ou round-robin | 🔄 |
| Middleware Prometheus no YARP | 🔄 |
| Métricas de proxy no Grafana | 🔄 |

---

## 📈 Próximos passos

- [ ] Configurar OpenTelemetry com spans entre serviços
- [ ] Subir logs para Loki e visualizar no Grafana Logs
- [ ] Implementar serviço de tarefas com CQRS + Worker
- [ ] Adicionar testes de integração com Testcontainers
- [ ] Adicionar cache híbrido (Memory + Redis)
- [ ] Automatizar deploy com GitHub Actions + Terraform

---

## 🌐 Contato 

---
