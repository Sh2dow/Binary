# Ensure you're in the root directory of the main repository
if (!(Test-Path ".git")) {
    Write-Host "This script must be run from the root of a Git repository." -ForegroundColor Red
    exit 1
}

# Get the latest commit message from the main repository
$latestCommitMessage = git log -1 --pretty=%B
if (-not $latestCommitMessage) {
    Write-Host "Failed to retrieve the latest commit message." -ForegroundColor Red
    exit 1
}

Write-Host "Using commit message: `"$latestCommitMessage`""

# Update and commit each submodule
git submodule update --init --recursive
git submodule foreach --recursive "
    git add .;
    git commit -m `"$latestCommitMessage`";
    git push
"

# Stage and commit submodule references in the main repository
git add .
git commit -m "$latestCommitMessage"
git push
