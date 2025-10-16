# 🚀 GitHub Pages Deployment Guide

## Quick Start (5 Minutes)

This guide will help you deploy the C# Async/Await training presentation to GitHub Pages.

---

## 📋 Prerequisites

- GitHub account (free): https://github.com/signup
- Files ready in: `C:\BobhaulRepos\lab`

---

## 🎯 Method 1: GitHub Web Interface (RECOMMENDED - No Git Knowledge Required)

### Step 1: Create Repository

1. Go to **https://github.com/new**
2. Fill in the form:
   - **Repository name**: `lab` (or `csharp-async-training`)
   - **Description**: `C# Async/Await Training - Vention Lab 2025-2026`
   - **Visibility**: ✅ **Public** (required for free GitHub Pages)
   - **Initialize**: Leave all checkboxes UNCHECKED
3. Click **"Create repository"**

### Step 2: Upload Files

1. On the empty repository page, click **"uploading an existing file"**
2. Drag and drop these files from `C:\BobhaulRepos\lab`:
   - ✅ `index.html` (REQUIRED)
   - ✅ `.nojekyll` (REQUIRED - prevents Jekyll processing)
   - ✅ `README.md` (recommended)
   - ✅ `Lesson Plan.md` (optional)
   - ✅ `Vention_Lab_2025-2026_CSharp_Async_Training.html` (optional backup)
3. Scroll down and click **"Commit changes"**

### Step 3: Enable GitHub Pages

1. Click **"Settings"** tab (top right)
2. In left sidebar, click **"Pages"**
3. Under **"Build and deployment"**:
   - **Source**: Select **"Deploy from a branch"**
   - **Branch**: Select **"main"** (or **"master"**)
   - **Folder**: Select **"/ (root)"**
4. Click **"Save"**

### Step 4: Access Your Site

1. Wait **1-2 minutes** for deployment (refresh the Settings → Pages page)
2. You'll see a message: **"Your site is live at https://YOUR-USERNAME.github.io/lab/"**
3. Click the link or visit: `https://YOUR-USERNAME.github.io/lab/`
4. 🎉 **Done!** Your presentation is now live!

---

## 🖥️ Method 2: Using Git Command Line

### Prerequisites
- Git installed: https://git-scm.com/downloads
- PowerShell or Command Prompt

### Step-by-Step Commands

```powershell
# 1. Navigate to your project
cd C:\BobhaulRepos\lab

# 2. Initialize Git repository (if not already done)
git init

# 3. Add all files
git add .

# 4. Create first commit
git commit -m "Initial commit: Add C# Async/Await training presentation"

# 5. Create repository on GitHub first (via web interface)
#    Then add it as remote (replace YOUR-USERNAME):
git remote add origin https://github.com/YOUR-USERNAME/lab.git

# 6. Rename branch to main (if needed)
git branch -M main

# 7. Push to GitHub
git push -u origin main
```

### Enable GitHub Pages
Follow **Method 1, Step 3** above to enable GitHub Pages.

---

## 🖱️ Method 3: Using GitHub Desktop (GUI - Easiest for Beginners)

### Download GitHub Desktop
- Windows: https://desktop.github.com/
- Install and sign in with your GitHub account

### Steps

1. **Open GitHub Desktop**
2. Click **"File"** → **"Add Local Repository"**
3. Click **"Choose..."** and select `C:\BobhaulRepos\lab`
4. If not a Git repository, click **"create a repository"**
5. Fill in:
   - **Name**: `lab`
   - **Description**: `C# Async/Await Training`
   - **Git Ignore**: None
   - **License**: None
6. Click **"Create Repository"**
7. Click **"Publish repository"** (top right)
8. Uncheck **"Keep this code private"** (must be public for free Pages)
9. Click **"Publish Repository"**

### Enable GitHub Pages
Follow **Method 1, Step 3** above.

---

## 🔄 Updating Your Presentation

### Via Web Interface
1. Go to your repository on GitHub
2. Click on the file you want to edit
3. Click the pencil icon (Edit)
4. Make changes
5. Click **"Commit changes"**
6. Wait 1-2 minutes for GitHub Pages to rebuild

### Via Command Line
```bash
# Make changes to your files locally
# Then:
git add .
git commit -m "Update presentation content"
git push origin main
```

### Via GitHub Desktop
1. Make changes to files locally
2. GitHub Desktop will show changes
3. Enter commit message in bottom left
4. Click **"Commit to main"**
5. Click **"Push origin"** (top right)

---

## 🔍 Troubleshooting

### Issue: "404 Page Not Found"

**Solutions:**
1. Ensure `index.html` exists in repository root
2. Check GitHub Pages is enabled (Settings → Pages)
3. Wait 2-5 minutes after first deployment
4. Verify repository is **Public** (Settings → General)
5. Check branch name matches (main vs master)

### Issue: "Site not updating"

**Solutions:**
1. Clear browser cache (Ctrl + F5)
2. Wait 1-2 minutes for GitHub to rebuild
3. Check commit was successful (repository main page)
4. Try incognito/private browsing mode

### Issue: "Styles not loading"

**Solutions:**
1. Ensure `.nojekyll` file is in repository root
2. Check file was uploaded correctly
3. Verify `index.html` has all CSS embedded

### Issue: "Cannot push to GitHub"

**Solutions:**
```bash
# If authentication fails, use Personal Access Token:
# 1. Go to GitHub → Settings → Developer settings → Personal access tokens → Tokens (classic)
# 2. Click "Generate new token (classic)"
# 3. Select "repo" scope
# 4. Use token as password when pushing
```

---

## ✅ Verification Checklist

Before declaring success, verify:

- [ ] Repository is **Public**
- [ ] `index.html` file exists in repository root
- [ ] `.nojekyll` file exists in repository root
- [ ] GitHub Pages is **enabled** (Settings → Pages)
- [ ] Branch is set to **main** or **master**
- [ ] Folder is set to **/ (root)**
- [ ] Wait **2 minutes** after first deployment
- [ ] Site URL shows: `https://YOUR-USERNAME.github.io/lab/`
- [ ] Slides load correctly with navigation working

---

## 🎨 Customization Options

### Change Repository Name
- Settings → General → Repository name → Rename
- URL will change to: `https://YOUR-USERNAME.github.io/NEW-NAME/`

### Custom Domain
1. Buy a domain (e.g., namecheap.com, godaddy.com)
2. Settings → Pages → Custom domain
3. Add your domain (e.g., `training.yourdomain.com`)
4. Add DNS records as instructed

### Private Repository (GitHub Pro)
- GitHub Pages works with private repos on paid plans
- Settings → General → Change visibility → Private

---

## 📊 Monitoring

### View Deployment Status
- Repository → **Actions** tab (if using GitHub Actions)
- Repository → **Environments** → **github-pages**

### Check Traffic
- Repository → **Insights** → **Traffic**
- See views, unique visitors, referring sites

---

## 🔐 Security Notes

1. **.nojekyll file is important** - prevents GitHub from processing your HTML
2. **No sensitive data** - All content is public
3. **HTTPS by default** - GitHub Pages serves over HTTPS
4. **No server-side code** - Static HTML only

---

## 📞 Support

### Official Documentation
- GitHub Pages: https://docs.github.com/pages
- Troubleshooting: https://docs.github.com/pages/getting-started-with-github-pages/troubleshooting-404-errors-for-github-pages-sites

### Community Help
- GitHub Community: https://github.community/
- Stack Overflow: https://stackoverflow.com/questions/tagged/github-pages

---

## 🎓 Next Steps

After deployment:

1. ✅ Share the link with your team
2. ✅ Bookmark the live URL
3. ✅ Update README.md with your actual URL
4. ✅ Add link to your GitHub profile README
5. ✅ Consider creating Uzbek version (separate repository)

---

**Happy Training! 🚀**

Prepared by: Vention Lab 2025-2026

