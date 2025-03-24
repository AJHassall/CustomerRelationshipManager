
## Getting Started

1.  **Clone the Repository:**

    ```bash
    git clone https://github.com/AJHassall/InvestorFlow_Excercise.git
    cd InvestorFlow_Excercise/ContactManagementApi
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
    dotnet run --project ContactManagementApi.csproj
    ```

    This will launch the API on `https://localhost:7001` (or a similar port). The console output will indicate the exact URL.

5.  **Swagger:**
    ```
    https://localhost:7001/swagger/index.html
    ```

## API Endpoints

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

## Running Tests

To run the unit tests:

1.  Navigate to the test project directory:

    ```bash
    cd ContactManagementApiTests
    ```

2.  Run the tests:

    ```bash
    dotnet test
    ```

