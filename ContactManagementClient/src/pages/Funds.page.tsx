import React, { useState, useEffect } from "react";
import { Modal, Button, TextInput } from "@mantine/core";

interface fund {
  fundId: number;
  name: string;

}

export function Funds() {
  const [funds, setfunds] = useState<fund[]>([]);
  const [opened, setOpened] = useState(false);
  const [newfund, setNewfund] = useState<fund>({
    fundId: 0,
    name: "",

  });

  useEffect(() => {
    async function getfunds() {
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

        const data: fund[] = await response.json();
        setfunds(data);
      } catch (error) {
        console.error("Error fetching funds:", error);
      }
    }
    getfunds();
  }, []);

  const handleCreatefund = async () => {
    try {
      const response = await fetch("http://localhost:8080/api/funds", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(newfund),
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const createdfund: fund = await response.json();
      setfunds([...funds, createdfund]);
      setOpened(false);
      setNewfund({ fundId: 0, name: ""});
    } catch (error) {
      console.error("Error creating fund:", error);
    }
  };

  const handleUpdatefund = async (updatedfund: fund) => {
    try {
      const response = await fetch(
        `http://localhost:8080/api/funds/${updatedfund.fundId}`,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(updatedfund),
        }
      );

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const updatedData: fund = await response.json();

      const updatedfunds = funds.map((fund) =>
        fund.fundId === updatedData.fundId ? updatedData : fund
      );
      setfunds(updatedfunds);
      setOpened(false);
    } catch (error) {
      console.error("Error updating fund:", error);
    }
  };

  const handleDeletefund = async (fundId: number) => {
    try {
      const response = await fetch(
        `http://localhost:8080/api/funds/${fundId}`,
        {
          method: "DELETE",
        }
      );

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const filteredfunds = funds.filter(
        (fund) => fund.fundId !== fundId
      );
      setfunds(filteredfunds);
    } catch (error) {
      console.error("Error deleting fund:", error);
    }
  };

  return (
    <div>
      <h1>Funds</h1>
      <Button onClick={() => setOpened(true)}>Create fund</Button>

      <Modal
        opened={opened}
        onClose={() => setOpened(false)}
        title="Create/Update Fund"
      >
        <TextInput
          label="Name"
          value={newfund.name}
          onChange={(event) =>
            setNewfund({ ...newfund, name: event.currentTarget.value })
          }
        />
        <Button
          onClick={
            newfund.fundId === 0
              ? handleCreatefund
              : () => handleUpdatefund(newfund)
          }
        >
          {newfund.fundId === 0 ? "Create" : "Update"}
        </Button>
      </Modal>

      <ul>
        {funds.map((fund) => (
          <li key={fund.fundId}>
            {fund.name}
            <Button
              onClick={() => {
                setNewfund(fund);
                setOpened(true);
              }}
            >
              Update
            </Button>
            <Button onClick={() => handleDeletefund(fund.fundId)}>
              Delete
            </Button>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default Funds;
