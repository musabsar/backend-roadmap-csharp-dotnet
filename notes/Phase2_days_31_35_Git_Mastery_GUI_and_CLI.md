Git Mastery – GitHub with Semantic Commits
Days 31–35

Mastering Git and GitHub is critical for backend development. I learned how to manage repositories using both GUI tools and the terminal. Below are the key principles and examples from each workflow:

Git via GUI (e.g., GitHub Desktop / VS Code)

Create/Clone Repository

GUI → File → Clone Repository / New Repository

Stage & Commit with Semantic Message

Example: feat: add user login form

Push to GitHub

Click "Push origin" after commit

Pull Latest Changes

Click "Pull origin" or "Fetch"

Resolve Merge Conflicts

Use visual merge tool






## Git via Terminal (CLI)

# Clone a repository
git clone https://github.com/user/repo.git

# Create a new repo
git init

# Add files to staging
git add .

# Commit with semantic message
git commit -m "fix: correct login bug"

# Push to remote
git push origin main

# Pull latest changes
git pull

# View history
git log --oneline

# Create & switch to new branch
git checkout -b feature/auth

# Merge branch
git merge feature/auth
