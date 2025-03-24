import React, { useState, useEffect } from "react";
import { Modal, Button, TextInput } from "@mantine/core";

interface Contact {
  contactId: number;
  name: string;
  email?: string;
  phoneNumber?: string;
}

export function Contacts() {
  const [contacts, setContacts] = useState<Contact[]>([]);
  const [opened, setOpened] = useState(false);
  const [newContact, setNewContact] = useState<Contact>({
    contactId: 0,
    name: "",
    email: "",
    phoneNumber: "",
  });

  useEffect(() => {
    async function getContacts() {
      try {
        const response = await fetch("https://localhost:7001/api/contacts", {
          method: "GET",
          headers: {
            accept: "*/*",
          },
        });

        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }

        const data: Contact[] = await response.json();
        setContacts(data);
      } catch (error) {
        console.error("Error fetching contacts:", error);
      }
    }
    getContacts();
  }, []);

  const handleCreateContact = async () => {
    try {
      const response = await fetch("https://localhost:7001/api/contacts/contacts", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(newContact),
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const createdContact: Contact = await response.json();
      setContacts([...contacts, createdContact]);
      setOpened(false);
      setNewContact({ contactId: 0, name: "", email: "", phoneNumber: "" });
    } catch (error) {
      console.error("Error creating contact:", error);
    }
  };

  const handleUpdateContact = async (updatedContact: Contact) => {
    try {
      const response = await fetch(
        `https://localhost:7001/api/contacts/${updatedContact.contactId}`,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(updatedContact),
        }
      );

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const updatedData: Contact = await response.json();

      const updatedContacts = contacts.map((contact) =>
        contact.contactId === updatedData.contactId ? updatedData : contact
      );
      setContacts(updatedContacts);
      setOpened(false);
    } catch (error) {
      console.error("Error updating contact:", error);
    }
  };

  const handleDeleteContact = async (contactId: number) => {
    try {
      const response = await fetch(
        `https://localhost:7001/api/contacts/${contactId}`,
        {
          method: "DELETE",
        }
      );

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const filteredContacts = contacts.filter(
        (contact) => contact.contactId !== contactId
      );
      setContacts(filteredContacts);
    } catch (error) {
      console.error("Error deleting contact:", error);
    }
  };

  return (
    <div>
      <h1>Contacts</h1>
      <Button onClick={() => setOpened(true)}>Create Contact</Button>

      <Modal
        opened={opened}
        onClose={() => setOpened(false)}
        title="Create/Update Contact"
      >
        <TextInput
          label="Name"
          value={newContact.name}
          onChange={(event) =>
            setNewContact({ ...newContact, name: event.currentTarget.value })
          }
        />
        <TextInput
          label="Email"
          value={newContact.email || ""}
          onChange={(event) =>
            setNewContact({ ...newContact, email: event.currentTarget.value })
          }
        />
        <TextInput
          label="Phone"
          value={newContact.phoneNumber || ""}
          onChange={(event) =>
            setNewContact({
              ...newContact,
              phoneNumber: event.currentTarget.value,
            })
          }
        />
        <Button
          onClick={
            newContact.contactId === 0
              ? handleCreateContact
              : () => handleUpdateContact(newContact)
          }
        >
          {newContact.contactId === 0 ? "Create" : "Update"}
        </Button>
      </Modal>

      <ul>
        {contacts.map((contact) => (
          <li key={contact.contactId}>
            {contact.name}
            <Button
              onClick={() => {
                setNewContact(contact);
                setOpened(true);
              }}
            >
              Update
            </Button>
            <Button onClick={() => handleDeleteContact(contact.contactId)}>
              Delete
            </Button>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default Contacts;
