import {
  Avatar,
  Button,
  Card,
  CardActions,
  CardContent,
  CardHeader,
  CardMedia,
  Typography,
} from "@mui/material";

import GuitarPlaceholder from "../../app/images/guitar-stock-default.png";
import KeyboardPlaceholder from "../../app/images/keyboard-stock-default.png";
import { Product } from "../../app/models/product";

interface IProps {
  product: Product;
}

export default function ProductCard({ product }: IProps) {
  return (
    <Card>
      <CardHeader
        avatar={
          <Avatar sx={{ bgcolor: "secondary.main" }}>
            {product.name.charAt(0).toUpperCase()}
          </Avatar>
        }
        title={product.name}
        titleTypographyProps={{
          sx: { fontWeight: "bold" },
        }}
      ></CardHeader>
      <CardMedia
        sx={{ objectFit: "contain", bgcolor: "primary.light" }}
        component="img"
        height="140"
        image={
          product.type.toLowerCase() === "guitar"
            ? GuitarPlaceholder
            : KeyboardPlaceholder
        }
        alt={product.name}
        title={product.name}
      />
      <CardContent>
        <Typography gutterBottom variant="h5" component="div" color="secondary">
          £{product.price}
        </Typography>
        <Typography variant="body2" color="text.secondary">
          {product.type} / {product.brand}
        </Typography>
      </CardContent>
      <CardActions>
        <Button size="small">Add to Cart</Button>
        <Button size="small">View product</Button>
      </CardActions>
    </Card>
  );
}
