#!/bin/bash
# ==========================================
# Apply EF Core Migrations to the database
# ==========================================

# Set environment (default: Development)
ENVIRONMENT=${1:-Development}

echo "Applying migrations for environment: $ENVIRONMENT"

# Path to API project
PROJECT_PATH="../src/AmazonAfrica.Api"

# Run migrations
dotnet ef database update --project $PROJECT_PATH --startup-project $PROJECT_PATH --environment $ENVIRONMENT

if [ $? -eq 0 ]; then
  echo "✅ Migrations applied successfully!"
else
  echo "❌ Failed to apply migrations."
  exit 1
fi
