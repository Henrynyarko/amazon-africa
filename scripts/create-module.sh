#!/bin/bash
# ==========================================
# Create a new module under Modules/
# ==========================================

MODULE_NAME=$1

if [ -z "$MODULE_NAME" ]; then
  echo "❌ Please provide a module name."
  echo "Usage: ./create-module.sh ModuleName"
  exit 1
fi

MODULE_PATH="../src/Modules/$MODULE_NAME"

# Check if module already exists
if [ -d "$MODULE_PATH" ]; then
  echo "❌ Module '$MODULE_NAME' already exists."
  exit 1
fi

# Create folder structure
mkdir -p "$MODULE_PATH"
mkdir -p "$MODULE_PATH/Controllers"
mkdir -p "$MODULE_PATH/Services"
mkdir -p "$MODULE_PATH/Models"

# Create a sample Controller file
cat <<EOL > "$MODULE_PATH/Controllers/${MODULE_NAME}Controller.cs"
using Microsoft.AspNetCore.Mvc;

namespace AmazonAfrica.Modules.${MODULE_NAME}.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ${MODULE_NAME}Controller : ControllerBase
    {
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Module ${MODULE_NAME} is working!");
        }
    }
}
EOL

echo "✅ Module '$MODULE_NAME' created successfully at $MODULE_PATH"
