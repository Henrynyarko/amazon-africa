                    AmazonAfrica Platform
                    Executive Summary

AmazonAfrica is a cloud-native, production-ready API platform built on .NET 8 and deployed on Microsoft Azure App Service using a secure, multi-environment CI/CD pipeline.

This repository demonstrates not only application development, but enterprise-grade delivery, security, and operational discipline. The system is designed to be safely deployed, continuously validated, and securely operated across Development, QA, and Production environments.

The focus of this project is how systems are run, not just how they are built.

High-Level Architecture

Core components:

AmazonAfrica.Api – ASP.NET Core 8 REST API

Azure App Service – Hosting with deployment slots

Azure SQL / EF Core – Persistence layer

Azure Key Vault – Secrets management (via Managed Identity)

GitHub Actions – CI/CD and DevSecOps automation

Azure AD (Entra ID) – Federated identity for pipelines (OIDC)

          Deployment strategy:

Environment-isolated deployments (dev, qa, production)

Slot-based blue-green deployment for production

Artifact-based promotion (build once, deploy many)

Repository Structure
├── src/
│   ├── AmazonAfrica.Api/      # Main API (ASP.NET Core 8)
│   ├── Modules/               # Modular feature boundaries
│   └── SharedKernel.Tests/    # Unit & domain tests
├── infra/
│   ├── dev/                   # Bicep IaC – Dev
│   ├── qa/                    # Bicep IaC – QA
│   └── prod/                  # Bicep IaC – Production
├── .github/workflows/
│   ├── dev-ci-cd.yml          # Dev pipeline
│   ├── qa-ci-cd.yml           # QA pipeline
│   └── prod-ci-cd.yml         # Production pipeline
└── scripts/                   # Automation & helper scripts


This structure intentionally separates:

Application logic

Infrastructure as Code

Delivery pipelines

Operational tooling

         CI/CD & Release Engineering
Pipeline Philosophy

The delivery model follows enterprise best practice:

Build once → Secure → Promote → Validate → Release

Each environment has a dedicated pipeline with increasing levels of control and governance.

Continuous Integration (CI)

Executed on every environment pipeline:

Dependency restore

Unit testing

Code coverage collection

Release build

Artifact publishing

Quality is enforced before deployment.

         DevSecOps (Security by Default)

Security is embedded into the pipeline, not added later.

Automated controls:

Static Application Security Testing (CodeQL)

Dependency and vulnerability scanning

GitHub Advanced Security integration

Security failures block promotion.

         Azure Authentication (Zero Trust)

All pipelines authenticate to Azure using OIDC Federated Identity.

Key properties:

No long-lived credentials

No client secrets

No credential rotation burden

Identity scoped per environment

This aligns with modern Zero Trust principles.

               Environment Strategy
Environment	Purpose	Controls
Dev	Fast feedback	Automatic deployment
QA	Validation	Manual approval
Production	Customer traffic	Manual approval + blue-green

Each environment is:

Isolated

Independently deployable

Governed via GitHub Environments

Production Deployment Model
Blue-Green Deployment (Slot Swap)

         Production deployments use Azure App Service slots:

Deploy to staging slot

Run smoke tests against staging

Manual approval

Slot swap to production

Post-swap health verification

This provides:

Zero-downtime releases

Instant rollback capability

Reduced deployment risk

           Observability & Health


The API exposes health endpoints used by both Azure and the pipelines:

/health – overall service health

Readiness & liveness checks

Deployments are not considered successful unless:

The application starts

Health checks pass

Endpoints respond correctly



            Secrets & Configuration Management

No secrets in source control

No secrets in pipelines

Application uses Managed Identity

Secrets retrieved at runtime from Azure Key Vault

Configuration is environment-specific and injected at deployment time.


            Governance & Operational Readiness

This repository is designed for team scale, not solo development.

Included governance practices:

Environment approvals

Artifact promotion

Security gates

Explicit deployment intent

Clear ownership boundaries

This makes the platform suitable for:

Regulated environments

Enterprise teams

Audited deployments
