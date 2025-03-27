import React, { useState, useEffect } from "react";
import {
  Modal,
  Button,
  SimpleGrid,
  Checkbox,
  Title,
  Group,
  Badge,
} from "@mantine/core";

interface Contact {
  contactId: number;
  name: string;
  email?: string;
  phoneNumber?: string;
}

interface Fund {
  fundId: number;
  name: string;
}

interface FundRelationship {
  contactId: number;
  fundId: number;
}

export function AssignContactsToFunds() {
  const [funds, setFunds] = useState<Fund[]>([]);
  const [contacts, setContacts] = useState<Contact[]>([]);
  const [selectedFund, setSelectedFund] = useState<Fund | null>(null);
  const [selectedContacts, setSelectedContacts] = useState<number[]>([]);
  const [modalOpened, setModalOpened] = useState(false);
  const [fundRelationships, setFundRelationships] = useState<
    FundRelationship[]
  >([]);

  useEffect(() => {
    async function getFunds() {
      try {
        const response = await fetch("http://localhost:8080/api/funds", {
          method: "GET",
          headers: {
            accept: "*/*",
          },
        });

        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }

        const data: Fund[] = await response.json();
        setFunds(data);
      } catch (error) {
        console.error("Error fetching funds:", error);
      }
    }

    async function getContacts() {
      try {
        const response = await fetch("http://localhost:8080/api/contacts", {
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

    async function getFundRelationships() {
      try {
        const response = await fetch("http://localhost:8080/api/fundrelationship", {
          method: "GET",
          headers: {
            accept: "*/*",
          },
        });

        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }

        const data: FundRelationship[] = await response.json();
        setFundRelationships(data);
      } catch (error) {
        console.error("Error fetching fund relationships:", error);
      }
    }

    getFunds();
    getContacts();
    getFundRelationships();
  }, []);

  const handleAssignClick = (fund: Fund) => {
    setSelectedFund(fund);
    setSelectedContacts(
      fundRelationships
        .filter((rel) => rel.fundId === fund.fundId)
        .map((rel) => rel.contactId)
    );
    setModalOpened(true);
  };

  const handleContactCheckboxChange = (contactId: number) => {
    setSelectedContacts((prev) =>
      prev.includes(contactId)
        ? prev.filter((id) => id !== contactId)
        : [...prev, contactId]
    );
  };

  const handleAssignConfirm = async () => {
    if (selectedFund && selectedContacts.length > 0) {
      try {
        const existingRelationships = fundRelationships.filter(
          (rel) => rel.fundId === selectedFund.fundId
        );
        for (const rel of existingRelationships) {
          await fetch(
            `http://localhost:8080/api/fundrelationship/${rel.contactId}/funds/${rel.fundId}`,
            { method: "DELETE" }
          );
        }

        // Create the new relationships
        for (const contactId of selectedContacts) {
          await fetch(
            `http://localhost:8080/api/fundrelationship/${contactId}/funds/${selectedFund.fundId}`,
            { method: "POST" }
          );
        }
        //reload the relationships
        const response = await fetch("http://localhost:8080/api/fundrelationship", {
          method: "GET",
          headers: {
            accept: "*/*",
          },
        });
        const data: FundRelationship[] = await response.json();
        setFundRelationships(data);

        console.log("Contacts assigned successfully!");
        setModalOpened(false);
      } catch (error) {
        console.error("Error assigning contacts:", error);
      }
    }
  };

  const isContactAssigned = (contactId: number, fundId: number) => {
    return fundRelationships.some(
      (rel) => rel.contactId === contactId && rel.fundId === fundId
    );
  };

  return (
    <div>
      <Title order={1}>Assign Contacts To Funds</Title>
      <SimpleGrid cols={2}>
        <div>
          <Title order={2}>Funds</Title>
          <ul>
            {funds.map((fund) => (
              <li key={fund.fundId}>
                {fund.name}
                <Button onClick={() => handleAssignClick(fund)}>Assign</Button>
              </li>
            ))}
          </ul>
        </div>
        <div>
          <Title order={2}>Contacts</Title>
          <ul>
            {contacts.map((contact) => (
              <li key={contact.contactId}>
                {contact.name}
                {funds.map((fund) =>
                  isContactAssigned(contact.contactId, fund.fundId) ? (
                    <Badge color="green" key={`badge-${contact.contactId}-${fund.fundId}`}>
                      Assigned to {fund.name}
                    </Badge>
                  ) : null
                )}
              </li>
            ))}
          </ul>
        </div>
      </SimpleGrid>

      <Modal
        opened={modalOpened}
        onClose={() => setModalOpened(false)}
        title="Assign Contacts"
      >
        {selectedFund && (
          <div>
            <Title order={3}>Assign contacts to {selectedFund.name}</Title>
            <Group dir="column">
              {contacts.map((contact) => (
                <Checkbox
                  key={contact.contactId}
                  label={contact.name}
                  checked={selectedContacts.includes(contact.contactId)}
                  onChange={() => handleContactCheckboxChange(contact.contactId)}
                />
              ))}
            </Group>
            <Button onClick={handleAssignConfirm}>Confirm Assignment</Button>
          </div>
        )}
      </Modal>
    </div>
  );
}

export default AssignContactsToFunds;