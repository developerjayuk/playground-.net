import {
  Avatar,
  List,
  ListItem,
  ListItemAvatar,
  ListItemText,
} from "@mui/material";
import { Product } from "../../app/models/product";

import GuitarPlaceholder from "guitar-stock-default.png";
import KeyboardPlaceholder from "keyboard-stock-default.png";

interface IProps {
  products: Product[];
}

export default function Catalog({ products }: IProps) {
  return (
    <div>
      {products.map((product) => (
        <List>
          <ListItem key={product.id}>
            <ListItemAvatar>
              <Avatar
                src={
                  product.type.toLowerCase() === "guitar"
                    ? GuitarPlaceholder
                    : KeyboardPlaceholder
                }
              ></Avatar>
            </ListItemAvatar>
            <ListItemText>{product.name}</ListItemText>
          </ListItem>
        </List>
      ))}
    </div>
  );
}
