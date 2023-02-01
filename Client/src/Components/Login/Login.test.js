import { findByText, fireEvent, screen } from "@testing-library/react";
import { renderWithProviders } from "../../utils/test-utils";
import Login from "./Login";
import axios from "axios";
jest.mock("axios");
test("Should successfully login", async () => {
  const response = { data: "testUserGuid" };
  axios.post = jest.fn().mockResolvedValue(response);

  renderWithProviders(<Login isLoginDialogOpen={true} />);
  const nameField = screen.getByLabelText("Name", { selector: "input" });
  const phoneNumberField = screen.getByLabelText("Phone number", {
    selector: "input",
  });
  const loginButton = screen.getByRole("button", { name: "Login" });

  expect(nameField).toBeInTheDocument();
  expect(phoneNumberField).toBeInTheDocument();
  expect(loginButton).toBeDisabled();
  fireEvent.change(nameField, { target: { value: "testName" } });
  fireEvent.change(phoneNumberField, {
    target: { value: "testPhoneNumber" },
  });
  expect(nameField.value).toBe("testName");
  expect(phoneNumberField.value).toBe("testPhoneNumber");
  expect(loginButton).toBeEnabled();
  fireEvent.click(loginButton);

  expect(await screen.findByText("Login is successful")).toBeInTheDocument();
});
