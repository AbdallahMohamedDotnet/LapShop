# LapShop v2 🛒💻

[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=microsoft&logoColor=white)](https://docs.microsoft.com/en-us/ef/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server)

A modern, full-featured e-commerce web application built with ASP.NET Core, specifically designed for laptop and computer hardware sales. LapShop v2 provides a comprehensive online shopping experience with advanced features for both customers and administrators.

## 🌟 Features

### 🛍️ Customer Features
- **Product Catalog**: Browse laptops and computer hardware with advanced filtering and search
- **Product Details**: Comprehensive product information with high-quality images and specifications
- **Shopping Cart**: Add, remove, and modify items with real-time price calculations
- **User Authentication**: Secure user registration, login, and profile management
- **Order Management**: Place orders, track order status, and view order history
- **Wishlist**: Save favorite products for later purchase
- **Product Reviews**: Read and write product reviews and ratings
- **Responsive Design**: Fully responsive UI that works on desktop, tablet, and mobile devices

### 🔧 Admin Features
- **Dashboard**: Comprehensive admin panel with sales analytics and key metrics
- **Product Management**: Add, edit, delete, and manage product inventory
- **Order Management**: Process orders, update order status, and manage fulfillment
- **User Management**: Manage customer accounts and permissions
- **Category Management**: Organize products into categories and subcategories
- **Reports**: Generate sales reports, inventory reports, and customer analytics
- **Content Management**: Manage site content, banners, and promotional materials

### 🔒 Technical Features
- **Authentication & Authorization**: JWT-based authentication with role-based access control
- **Security**: Input validation, CSRF protection, and secure password handling
- **Performance**: Optimized database queries, caching, and efficient asset loading
- **API Integration**: RESTful APIs for seamless frontend-backend communication
- **Database**: Entity Framework Core with SQL Server for robust data management
- **Email Integration**: Automated email notifications for orders, registration, and promotions

## 🏗️ Architecture

LapShop v2 follows the **Clean Architecture** principles with the following layers:

```
├── LapShop.Web/                 # Presentation Layer (MVC/API Controllers)
├── LapShop.Application/         # Application Layer (Services, DTOs, Interfaces)
├── LapShop.Domain/              # Domain Layer (Entities, Value Objects)
├── LapShop.Infrastructure/      # Infrastructure Layer (Data Access, External Services)
└── LapShop.Tests/              # Test Projects
```

## 🛠️ Technology Stack

### Backend
- **Framework**: ASP.NET Core 8.0
- **ORM**: Entity Framework Core
- **Database**: SQL Server
- **Authentication**: ASP.NET Core Identity
- **API**: RESTful Web APIs
- **Validation**: FluentValidation
- **Mapping**: AutoMapper
- **Logging**: Serilog

### Frontend
- **Framework**: ASP.NET Core MVC with Razor Pages
- **Styling**: Bootstrap 5 + Custom CSS
- **JavaScript**: jQuery + Modern ES6
- **Icons**: Font Awesome
- **Charts**: Chart.js (for admin dashboard)

### Development Tools
- **IDE**: Visual Studio 2022 / Visual Studio Code
- **Package Manager**: NuGet
- **Version Control**: Git
- **Containerization**: Docker (optional)

## 🚀 Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB for development)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/AbdallahMohamedDotnet/LapShopv2.git
   cd LapShopv2
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Update database connection string**
   
   Edit `appsettings.json` in the web project:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=LapShopV2;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

4. **Apply database migrations**
   ```bash
   dotnet ef database update
   ```

5. **Seed initial data (optional)**
   ```bash
   dotnet run --seed-data
   ```

6. **Run the application**
   ```bash
   dotnet run
   ```

7. **Access the application**
   - Navigate to `https://localhost:5001` or `http://localhost:5000`
   - Admin panel: `https://localhost:5001/admin`

### Docker Support

Run with Docker:
```bash
docker-compose up -d
```

## 📝 Configuration

### Environment Variables
```bash
# Database
ConnectionStrings__DefaultConnection=your_connection_string

# Email Settings
EmailSettings__SmtpHost=smtp.gmail.com
EmailSettings__SmtpPort=587
EmailSettings__FromEmail=noreply@lapshop.com
EmailSettings__FromName=LapShop

# JWT Settings
JwtSettings__SecretKey=your_secret_key
JwtSettings__Issuer=lapshop.com
JwtSettings__Audience=lapshop-users
JwtSettings__ExpirationHours=24

# Payment Gateway (if applicable)
PaymentSettings__PublishableKey=your_stripe_publishable_key
PaymentSettings__SecretKey=your_stripe_secret_key
```

## 🗄️ Database Schema

The application uses Entity Framework Core with the following main entities:

- **User**: Customer and admin user accounts
- **Product**: Laptop and hardware product information
- **Category**: Product categorization
- **Order**: Customer orders and order items
- **Cart**: Shopping cart functionality
- **Review**: Product reviews and ratings
- **Inventory**: Product stock management

## 🧪 Testing

Run the test suite:
```bash
# Run all tests
dotnet test

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"
```

### Test Structure
- **Unit Tests**: Business logic and service layer testing
- **Integration Tests**: API endpoint testing
- **UI Tests**: Selenium-based end-to-end testing

## 📊 API Documentation

The application includes Swagger/OpenAPI documentation. After running the application, visit:
- Swagger UI: `https://localhost:5001/swagger`
- API JSON: `https://localhost:5001/swagger/v1/swagger.json`

### Main API Endpoints
```
GET    /api/products              # Get all products
GET    /api/products/{id}         # Get product by ID
POST   /api/products              # Create product (Admin)
PUT    /api/products/{id}         # Update product (Admin)
DELETE /api/products/{id}         # Delete product (Admin)

GET    /api/cart                  # Get user cart
POST   /api/cart/add              # Add item to cart
PUT    /api/cart/update           # Update cart item
DELETE /api/cart/remove/{id}      # Remove item from cart

POST   /api/orders                # Place order
GET    /api/orders                # Get user orders
GET    /api/orders/{id}           # Get order details
```

## 🔧 Development

### Code Standards
- Follow C# coding conventions
- Use meaningful variable and method names
- Write XML documentation for public APIs
- Implement proper error handling
- Use dependency injection
- Follow SOLID principles

### Git Workflow
1. Create feature branch: `git checkout -b feature/your-feature-name`
2. Make changes and commit: `git commit -m "Add your feature"`
3. Push branch: `git push origin feature/your-feature-name`
4. Create pull request

## 📁 Project Structure

```
LapShopv2/
├── src/
│   ├── LapShop.Web/                    # Web application
│   │   ├── Controllers/                # MVC Controllers
│   │   ├── Views/                      # Razor Views
│   │   ├── wwwroot/                    # Static files
│   │   ├── Models/                     # View Models
│   │   └── Program.cs                  # Application entry point
│   ├── LapShop.Application/            # Application services
│   │   ├── Services/                   # Business logic services
│   │   ├── DTOs/                       # Data transfer objects
│   │   ├── Interfaces/                 # Service interfaces
│   │   └── Validators/                 # Input validation
│   ├── LapShop.Domain/                 # Domain entities
│   │   ├── Entities/                   # Domain models
│   │   ├── Enums/                      # Enumerations
│   │   └── Constants/                  # Domain constants
│   └── LapShop.Infrastructure/         # Data access & external services
│       ├── Data/                       # DbContext and configurations
│       ├── Repositories/               # Data repositories
│       ├── Services/                   # External service implementations
│       └── Migrations/                 # EF Core migrations
├── tests/
│   ├── LapShop.Tests.Unit/            # Unit tests
│   ├── LapShop.Tests.Integration/     # Integration tests
│   └── LapShop.Tests.UI/              # UI/E2E tests
├── docs/                              # Documentation
├── scripts/                           # Build and deployment scripts
├── .gitignore
├── README.md
├── LapShopv2.sln                      # Solution file
└── docker-compose.yml                 # Docker configuration
```

## 🚀 Deployment

### Production Deployment

1. **Build for production**
   ```bash
   dotnet publish -c Release -o ./publish
   ```

2. **Environment Configuration**
   - Set up production database
   - Configure environment variables
   - Set up SSL certificates
   - Configure logging

3. **Deploy Options**
   - **IIS**: Deploy to Windows Server with IIS
   - **Linux**: Deploy to Linux server with Nginx
   - **Azure**: Deploy to Azure App Service
   - **Docker**: Deploy using Docker containers

### Performance Optimization
- Enable response caching
- Configure output caching
- Optimize database queries
- Use CDN for static assets
- Enable compression

## 🤝 Contributing

We welcome contributions! Please follow these guidelines:

1. Fork the repository
2. Create a feature branch
3. Follow coding standards
4. Add tests for new functionality
5. Update documentation
6. Submit a pull request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Abdallah Mohamed**
- GitHub: [@AbdallahMohamedDotnet](https://github.com/AbdallahMohamedDotnet)
- LinkedIn: www.linkedin.com/in/abdallah-mohamed-6724ba297
- Email : abdoooomohamed88@gamil.com
## 🙏 Acknowledgments

- ASP.NET Core team for the excellent framework
- Entity Framework Core for robust data access
- Bootstrap team for the responsive UI framework
- The open-source community for various packages and tools

## 📞 Support

If you encounter any issues or have questions:

1. Check the [Issues](https://github.com/AbdallahMohamedDotnet/LapShopv2/issues) page
2. Create a new issue with detailed description
3. Contact the maintainer

---

**LapShop v2** - Building the future of online laptop retail 🚀
