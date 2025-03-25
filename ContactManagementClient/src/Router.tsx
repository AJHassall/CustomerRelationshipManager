import { createBrowserRouter, RouterProvider } from "react-router-dom";
import { RootLayout } from "./Layout"; // Import the Layout component
import { AssignContactsToFunds } from "./pages/AssignContactsToFunds.page";
import { Funds } from "./pages/Funds.page";
import { Contacts } from "./pages/Contacts.page";
import Home from "./pages/Home.page";

const router = createBrowserRouter(
  [
    {
      path: "/",
      element: (
        <RootLayout>
          <Home />
        </RootLayout>
      ),

    },
    {
      path: "/assign-contacts-to-funds",
      element: (
        <RootLayout>
          <AssignContactsToFunds />
        </RootLayout>
      ),

    },
    {
      path: "/funds",
      element: (
        <RootLayout>
          <Funds />
        </RootLayout>
      ),
    },
    {
      path: "/contacts",
      element: (
        <RootLayout>
          <Contacts />
        </RootLayout>
      ),
    },
  ],
  { basename: import.meta.env.BASE_URL }
);

export function Router() {
  return <RouterProvider router={router} />;
}
