# Vention Lab 2025-2026: C# Async/Await Training

![Training Status](https://img.shields.io/badge/Status-Active-brightgreen)
![Slides](https://img.shields.io/badge/Slides-50-blue)
![Duration](https://img.shields.io/badge/Duration-90min-orange)

## 📚 About This Training

Comprehensive training materials for mastering C# Async/Await and Concurrency concepts. This 50-slide presentation covers everything from thread starvation problems to advanced async patterns, designed for junior to mid-level developers.

### Key Learning Objectives:
- ✅ Understanding the thread starvation problem
- ✅ Mastering async/await syntax and state machines
- ✅ Avoiding deadlocks and common pitfalls
- ✅ Best practices for scalable applications

## 🚀 Live Demo

**View the presentation online:** [GitHub Pages Link](https://YOUR-USERNAME.github.io/lab/)

> Replace `YOUR-USERNAME` with your actual GitHub username after deployment

## 📁 Files

- **`index.html`** - Main presentation file (GitHub Pages entry point)
- **`Vention_Lab_2025-2026_CSharp_Async_Training.html`** - Original training file (same as index.html)
- **`Lesson Plan.md`** - Original lesson plan and structure

## 🎯 Topics Covered

1. **Foundation & Context** (Slides 1-8)
   - Thread Starvation Problem
   - ThreadPool & Context Switching
   - I/O-Bound vs CPU-Bound Operations
   - Non-Blocking I/O (IOCP)

2. **Async/Await Fundamentals** (Slides 9-20)
   - Core Syntax & Keywords
   - Task Return Types
   - State Machine Mechanics
   - ConfigureAwait(false)

3. **Pitfalls & Best Practices** (Slides 21-35)
   - Deadlock Prevention
   - Exception Handling
   - CancellationToken Usage
   - async void Anti-patterns

4. **Concurrency & Parallelism** (Slides 36-42)
   - Task.WhenAll / WhenAny
   - Task.Run for CPU-bound work
   - Parallel.For & Parallel.ForEach
   - SemaphoreSlim

5. **Advanced Topics** (Slides 43-50)
   - IAsyncEnumerable<T>
   - Testing Async Code
   - Migration Strategies
   - Best Practices Summary

## 🔧 Local Usage

### Option 1: Direct File Opening
Simply open `index.html` or `Vention_Lab_2025-2026_CSharp_Async_Training.html` in any modern web browser.

### Option 2: Local Web Server
For best experience, serve via a local web server:

```bash
# Using Python 3
python -m http.server 8000

# Using Node.js (http-server)
npx http-server -p 8000

# Using PHP
php -S localhost:8000
```

Then open: `http://localhost:8000`

## 📖 Navigation Controls

- **→ Arrow** or **Right Arrow Key**: Next slide
- **← Arrow** or **Left Arrow Key**: Previous slide
- **Mouse Click**: Click navigation arrows at the bottom center
- **Keyboard Shortcuts**: Use arrow keys for quick navigation

## 🌐 Deploy to GitHub Pages

Follow these steps to deploy your own copy:

### Method 1: GitHub Web Interface (Easiest)

1. **Create a new repository** on GitHub:
   - Go to https://github.com/new
   - Name it `lab` (or any name you prefer)
   - Choose "Public" (required for free GitHub Pages)
   - Click "Create repository"

2. **Upload files**:
   - Click "uploading an existing file"
   - Drag and drop these files:
     - `index.html`
     - `.nojekyll`
     - `README.md`
     - `Lesson Plan.md` (optional)
   - Click "Commit changes"

3. **Enable GitHub Pages**:
   - Go to repository **Settings** → **Pages**
   - Under "Source", select **Deploy from a branch**
   - Select branch: **main** (or **master**)
   - Select folder: **/ (root)**
   - Click **Save**

4. **Access your site**:
   - Wait 1-2 minutes for deployment
   - Visit: `https://YOUR-USERNAME.github.io/lab/`
   - 🎉 Your presentation is live!

### Method 2: Git Command Line

```bash
# Navigate to your project directory
cd C:\BobhaulRepos\lab

# Initialize git repository (if not already initialized)
git init

# Add all files
git add .

# Commit files
git commit -m "Add C# Async/Await training presentation"

# Add remote repository (replace YOUR-USERNAME)
git remote add origin https://github.com/YOUR-USERNAME/lab.git

# Push to GitHub
git branch -M main
git push -u origin main

# Now enable GitHub Pages via Settings → Pages as described above
```

### Method 3: GitHub Desktop

1. Open GitHub Desktop
2. Click "Add" → "Add Existing Repository"
3. Choose `C:\BobhaulRepos\lab`
4. Click "Publish repository"
5. Enable GitHub Pages via Settings → Pages (see Method 1, step 3)

## 🔄 Updating the Presentation

After making changes to your presentation:

```bash
# Add changes
git add .

# Commit with a message
git commit -m "Update presentation content"

# Push to GitHub
git push origin main
```

GitHub Pages will automatically rebuild (takes 1-2 minutes).

## ✨ Features

- 📱 **Responsive Design**: Works on desktop, tablet, and mobile
- ⌨️ **Keyboard Navigation**: Arrow keys for quick navigation
- 🎨 **Modern UI**: Clean, professional design with syntax highlighting
- 📖 **Code Examples**: Real-world C# code with explanations
- 🔗 **References**: Direct links to Microsoft Docs
- 💡 **Best Practices**: Highlighted tips and warnings throughout

## 📚 Additional Resources

- [Microsoft Docs - Async Programming](https://docs.microsoft.com/dotnet/csharp/async)
- [Task-based Asynchronous Pattern (TAP)](https://docs.microsoft.com/dotnet/standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap)
- [ASP.NET Core Performance Best Practices](https://docs.microsoft.com/aspnet/core/performance/performance-best-practices)
- [Stephen Cleary's Blog](https://blog.stephencleary.com/)
- [Stephen Toub's .NET Blog](https://devblogs.microsoft.com/dotnet/author/toub/)

## 🤝 Contributing

This training material is maintained by Vention Lab. For suggestions or improvements:

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Submit a pull request

## 📄 License

Training materials created for Vention Lab 2025-2026.

---

**Lecturer:** Abubakr Bakhromov  
**Organization:** Vention Lab  
**Year:** 2025-2026  
**Target Audience:** Junior to Mid-Level .NET Developers  
**Duration:** ~90 minutes

