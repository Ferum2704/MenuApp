import { screen } from "@testing-library/react";
import { renderWithProviders } from "../../../utils/test-utils";
import MenuItemCategories from "./MenuItemCategories";
import axios from "axios";
jest.mock("axios");
const categorizedMenuItems = [
  {
    id: "b5b9de64-e210-437d-bcbb-ec1118ba904d",
    name: "Salads",
    priority: 2,
    menuItems: [
      {
        id: "d2c4350b-4ac7-420b-b474-25bb9c0292c2",
        name: "Caesar",
        photoName: null,
        price: 300,
      },
      {
        id: "db8388a2-b2e8-452d-8766-793e46302977",
        name: "Olivier",
        photoName: null,
        price: 220,
      },
    ],
  },
  {
    id: "b5b9de27-e210-437d-bcbb-ec1118ba904d",
    name: "Drinks",
    priority: 3,
    menuItems: [
      {
        id: "8250190d-33ae-425f-bbce-cf1fa301f31b",
        name: "Apple juice",
        photoName: null,
        price: 50,
      },
    ],
  },
];
test("Should return categorized items", async () => {
  const response = { data: categorizedMenuItems };
  axios.get = jest.fn().mockResolvedValue(response);
  const { store } = renderWithProviders(<MenuItemCategories />);
  for (const category of categorizedMenuItems) {
    expect(await screen.findByText(category.name)).toBeInTheDocument();
  }
});
