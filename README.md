# EcoRater: Your Triple-Bottom-Line Sustainability Assessor

## I. Introduction and Project Overview

### A. Project Origin
The idea behind EcoRater was conceived during a summer school assignment at Chalmers University of Technology. This assignment was part of the ENHANCE Summer School in Sustainable Entrepreneurship and Innovation (SEI), which aimed at providing a holistic understanding of how entrepreneurial initiatives can contribute to solving environmental challenges.

### B. Project Rationale
With sustainability becoming a pivotal concern across the globe, there's a significant gap between entrepreneurship, innovation, and sustainability. EcoRater is an attempt to bridge this gap by providing an intuitive platform for assessing sustainability practices across different facets of business operations.

### C. Project Description
EcoRater emerges with a vision to simplify sustainability assessment for individuals, entrepreneurs, and businesses. Its AI-driven interactive platform offers a Triple-Bottom-Line approach focusing on People, Planet, and Profit, providing instant ratings with actionable feedback based on responses to a set of curated questions.

### D. Key Features
Triple-Bottom-Line Focus: Evaluating environmental, social, and economic aspects.
Interactive Questionnaire: A set of intuitive questions guiding users toward a sustainability rating.
Instant Ratings with Actionable Feedback: Providing immediate insights and recommendations.

### E. Vision for EcoRater
EcoRater aims to demystify sustainability assessment, providing an educative platform that not only rates but also guides individuals and businesses towards sustainable practices.

The inspiration for EcoRater was further fueled by a presentation delivered by Julian Fleck on LLM during the last session of the summer school on a Thursday.



## II. Technical Stack

### A. Backend Framework: ASP.NET Core MVC
EcoRater employs ASP.NET Core MVC as its backend framework, benefiting from its robustness, scalability, and ease of integration with various other technologies. The Model-View-Controller (MVC) architecture facilitates a logical separation of concerns, simplifying the development process.

Version: ASP.NET Core 7.0.
Language: C#.
Dependencies: Newtonsoft.Json for handling JSON data, Entity Framework Core for database operations, and AutoMapper for object-object mapping.

### B. Database & ORM: SQL Server & Entity Framework Core
SQL Server is used as the database solution due to its reliability, security features, and robust data management capabilities. Entity Framework Core acts as the Object-Relational Mapper (ORM), streamlining the data access layer.

Version: SQL Server 2019, Entity Framework Core 7.0.
Migrations: Code-first migrations allowing for easy versioning and replication of the database schema.
Data Seeding: Initial data seeding for testing and deployment purposes.

### C. Authentication: ASP.NET Core Identity
Authentication and authorization are crucial for securing the EcoRater platform. ASP.NET Core Identity is used for managing user information, and securing the application with robust authentication and authorization mechanisms.

Roles: Defined roles for regular users, administrators, and moderators.
Security: Password hashing, multi-factor authentication possibility, and OAuth 2.0 integration.

### D. Frontend Framework: Bootstrap
Bootstrap is utilized for crafting a responsive and modern user interface. Its pre-built components accelerate the development process while ensuring a consistent and accessible design across various devices and screen sizes.

Themes: Custom themes to adhere to the EcoRater brand guidelines.
Accessibility: ARIA attributes and accessible components ensuring an inclusive user experience.

### E. Hosting: Azure App Service
Azure App Service provides a reliable, scalable, and secure environment for hosting the EcoRater web application. Continuous deployment, monitoring, and diagnostic tools offered by Azure streamline the deployment and maintenance process.

Environment: Production and staging environments for seamless deployment and testing.
Monitoring: Application Insights for real-time monitoring and diagnostics.
Backup & Restore: Regular backups and easy restoration procedures ensuring data integrity and availability.

### F. Version Control: Git & GitHub
Version control is indispensable for collaborative development. Git, along with GitHub, is used for source code management, issue tracking, and project documentation.

Repository: Hosted on GitHub, enabling collaborative development and version control.
