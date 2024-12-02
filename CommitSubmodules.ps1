# Check if a commit message was provided
if ($args.Count -eq 0) {
    Write-Host "No commit message provided. Using the latest commit message from the main repository." -ForegroundColor Yellow

    # Get the latest commit message from the main repository
    $commitMessage = git log -1 --pretty=%B
    if (-not $commitMessage) {
        Write-Host "Failed to retrieve the latest commit message. Exiting." -ForegroundColor Red
        exit 1
    }
} else {
    $commitMessage = $args[0]
}

Write-Host "Using commit message: `"$commitMessage`""

# Ensure in the main repository
if (!(Test-Path ".git")) {
    Write-Host "This script must be run from the root of a Git repository." -ForegroundColor Red
    exit 1
}

# Update submodules
git submodule update --init --recursive

# Iterate through submodules
$submodules = git config --file .gitmodules --name-only --get-regexp path | ForEach-Object { $_.Split(".")[1] }
foreach ($submodule in $submodules) {
    Write-Host "Processing submodule: $submodule" -ForegroundColor Green

    Push-Location $submodule

    # Ensure we're on a branch, not a detached HEAD
    $currentBranch = git symbolic-ref --short HEAD 2>$null
    if (-not $currentBranch) {
        Write-Host "Detached HEAD detected. Checking out or creating 'master' branch." -ForegroundColor Yellow
        git checkout master 2>$null || git checkout -b master
    }

    # Stage, commit, and push changes
    git add .
    git commit -m "$commitMessage" 2>$null || Write-Host "Nothing to commit for $submodule." -ForegroundColor Yellow
    git push --set-upstream origin HEAD 2>$null || Write-Host "Failed to push changes for $submodule. Check permissions." -ForegroundColor Red

    Pop-Location
}

# Commit changes to the main repository
Write-Host "Committing submodule references in the main repository..." -ForegroundColor Green
git add .
git commit -m "$commitMessage" 2>$null || Write-Host "Nothing to commit in the main repository." -ForegroundColor Yellow
git push --set-upstream origin HEAD || Write-Host "Failed to push main repository changes. Check upstream branch configuration." -ForegroundColor Red
