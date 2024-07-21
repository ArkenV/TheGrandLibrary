mkdir {{REPOSITORY}}
cd {{REPOSITORY}}
git init --initial-branch=master
echo "# {{REPOSITORY}}" > README.md
git add .
git commit -m "Initial commit (added README.md)"
gh repo create {{REPOSITORY}} --private --source . --remote origin --push
code .