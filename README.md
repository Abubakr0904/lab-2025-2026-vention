# Vention Lab 2025-2026: .NET Advanced Training

🎓 **Comprehensive .NET training presentations covering advanced topics for professional development**

## 📚 Presentations

### 1. C# Async/Await & Concurrency Training
**50 slides | ~90 minutes | Junior to Mid-Level**

Master asynchronous programming patterns that enable scalable, high-performance applications.

**Topics Covered:**
- The Thread Starvation Problem
- Non-Blocking I/O & IOCP
- async/await Syntax & State Machines
- Deadlock Prevention (SynchronizationContext, ConfigureAwait)
- Task.WhenAll, Task.WhenAny, CancellationToken
- Best Practices for ASP.NET Core

**[📖 View Presentation](https://abubakr0904.github.io/lab-2025-2026-vention/async-await.html)**

**Assignment:**
- Convert legacy sync code to async: [Assignment_LegacySyncCode.cs](./Assignment_LegacySyncCode.cs)

---

### 2. .NET Best Practices Training
**100 slides | ~120 minutes | Junior to Mid-Level**

Professional patterns for building production-ready, maintainable systems.

**Four Pillars:**

1. **Logging & Observability**
   - Structured logging with Serilog
   - Log levels and contexts
   - Centralized logging & correlation IDs
   - Performance optimization

2. **Configuration Management**
   - appsettings.json & environment overrides
   - Strongly-typed configuration (IOptions)
   - Secret management (User Secrets, Azure Key Vault)
   - Multi-environment strategies

3. **Error Handling**
   - Custom exceptions & global handlers
   - Retry patterns with Polly
   - Result wrappers vs exceptions
   - Graceful degradation

4. **Documentation**
   - Documentation as code
   - ADRs (Architecture Decision Records)
   - API documentation (Swagger/OpenAPI)
   - CI/CD integration for docs

**[📖 View Presentation](https://abubakr0904.github.io/lab-2025-2026-vention/best-practices.html)**

---

## 🚀 Quick Start

### Online (GitHub Pages)
Visit the live site: **https://abubakr0904.github.io/lab-2025-2026-vention/**

### Local Development
1. Clone the repository
   ```bash
   git clone https://github.com/Abubakr0904/lab-2025-2026-vention.git
   cd lab-2025-2026-vention
   ```

2. Open `index.html` in your browser
   ```bash
   # Windows
   start index.html
   
   # macOS
   open index.html
   
   # Linux
   xdg-open index.html
   ```

### Navigation Features
- **Arrow Keys:** Navigate slides (← →)
- **Jump to Slide:** Enter slide number in bottom-right input
- **Main Controls:** Previous/Next buttons at bottom center

---

## 📂 Repository Structure

```
lab-2025-2026-vention/
├── index.html                      # Landing page with presentation selection
├── async-await.html                # 50-slide Async/Await presentation
├── best-practices.html             # 100-slide Best Practices presentation
├── styles.css                      # Shared presentation styles
├── presentation.js                 # Shared navigation logic
├── Assignment_LegacySyncCode.cs    # Async conversion assignment
├── README.md                       # This file
├── .gitignore                      # Git ignore rules
├── .nojekyll                       # GitHub Pages configuration
└── .github/
    └── workflows/
        └── deploy.yml              # GitHub Actions deployment
```

---

## 🎯 Learning Objectives

### After completing these trainings, you will be able to:

**Async/Await:**
- ✅ Explain why async prevents thread starvation
- ✅ Identify I/O-bound vs CPU-bound operations
- ✅ Avoid common pitfalls (deadlocks, fire-and-forget)
- ✅ Apply best practices in ASP.NET Core and UI applications

**Best Practices:**
- ✅ Implement structured logging with proper context
- ✅ Manage configuration securely across environments
- ✅ Build resilient error handling strategies
- ✅ Create and maintain production-quality documentation

---

## 👨‍🏫 Instructor

**Abubakr Bakhromov**
- Software Engineer at Vention
- .NET Developer & Technical Trainer

---

## 📖 Resources

### Official Documentation
- [Microsoft Docs - Async Programming](https://docs.microsoft.com/dotnet/csharp/async)
- [ASP.NET Core Performance Best Practices](https://docs.microsoft.com/aspnet/core/performance/performance-best-practices)
- [.NET Logging](https://docs.microsoft.com/dotnet/core/extensions/logging)
- [Configuration in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/configuration/)

### Community Resources
- [Stephen Cleary's Blog](https://blog.stephencleary.com) - Async/Await expert
- [ConfigureAwait FAQ](https://devblogs.microsoft.com/dotnet/configureawait-faq/) - Stephen Toub
- [Serilog](https://serilog.net/) - Structured logging framework

---

## 🤝 Contributing

Found a typo or have a suggestion? Contributions are welcome!

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/improvement`)
3. Commit your changes (`git commit -m 'Add improvement'`)
4. Push to the branch (`git push origin feature/improvement`)
5. Open a Pull Request

---

## 📜 License

This project is created for educational purposes as part of Vention's internal training program.

---

## 🙏 Acknowledgments

- **Microsoft Docs** - Comprehensive .NET documentation
- **Stephen Cleary & Stephen Toub** - Async/await expertise
- **Vention Team** - Support and feedback
- **AI Assistant** - Content generation and structuring

---

## 📧 Contact

For questions or feedback:
- **GitHub Issues:** [Create an issue](https://github.com/Abubakr0904/lab-2025-2026-vention/issues)
- **Instructor:** Abubakr Bakhromov

---

<p align="center">
  <sub>🤖 Made by AI • Reviewed by Abubakr Bakhromov</sub><br>
  <sub>© 2025 Vention Lab Training Program</sub>
</p>
