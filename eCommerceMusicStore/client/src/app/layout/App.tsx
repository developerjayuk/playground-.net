import { useEffect, useState } from "react";
import axios from "axios";
import { Product } from "../models/product";
import Catalog from "../../features/catalog/Catalog";
import { Typography } from "@mui/material";

function App() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    getProducts();
  }, []);

  async function getProducts() {
    const products = await axios.get<Product[]>(
      "http://localhost:5195/api/products"
    );

    setProducts(products.data);
  }

  return (
    <>
      <Typography variant="h1">JJ's Music Store</Typography>
      <Catalog products={products} />
    </>
  );
}

export default App;
