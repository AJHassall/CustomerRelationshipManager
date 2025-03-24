
## Prerequisites

* **.NET 8 SDK:** Download and install the .NET 8 SDK from [Microsoft's .NET website](https://dotnet.microsoft.com/download).

## Getting Started

1.  **Clone the Repository:**

    ```bash
    git clone [https://github.com/AJHassall/InvestorFlow_Excercise.git](https://www.google.com/search?q=https://github.com/AJHassall/InvestorFlow_Excercise.git)
    cd InvestorFlow_Excercise
    ```

2.  **Restore Dependencies:**

    Navigate to the project directory and restore the NuGet packages:

    ```bash
    dotnet restore
    ```

3.  **Build the Project:**

    Build the project to ensure all dependencies are resolved and the code compiles successfully:

    ```bash
    dotnet build
    ```

4.  **Run the API:**

    Start the API application:

    ```bash
    dotnet run --project ContactManagementApi/ContactManagementApi.csproj
    ```

    This will launch the API on `https://localhost:7001` (or a similar port). The console output will indicate the exact URL.

5.  **Access Swagger UI (Optional):**

    If you want to view and test the API endpoints using Swagger UI, open your browser and navigate to:

    ```
    https://localhost:7001/swagger/index.html
    ```

    Swagger UI provides an interactive documentation and testing environment for your API.

## API Endpoints

The API provides the following endpoints:

* **Contacts:**
    * `GET /api/contacts`: Retrieves all contacts.
    * `GET /api/contacts/{id}`: Retrieves a contact by ID.
    * `POST /api/contacts`: Creates a new contact.
    * `PUT /api/contacts/{id}`: Updates a contact.
    * `DELETE /api/contacts/{id}`: Deletes a contact.
* **Funds:**
    * `GET /api/funds`: Retrieves all funds.
    * `GET /api/funds/{id}`: Retrieves a fund by ID.
    * `POST /api/funds`: Creates a new fund.
    * `PUT /api/funds/{id}`: Updates a fund.
    * `DELETE /api/funds/{id}`: Deletes a fund.
* **Contact Fund Assignments:**
    * `POST /api/contactfundassignments`: Creates a new contact-fund assignment.
    * `DELETE /api/contactfundassignments`: Deletes a contact fund assignment.

## Database

The project uses an in-memory database by default. This means that data will not persist between application restarts.

## Running Tests

To run the unit tests:

1.  Navigate to the test project directory:

    ```bash
    cd ContactManagementApi.Tests
    ```

2.  Run the tests:

    ```bash
    dotnet test
    ```

    This will execute all unit tests and display the results.
