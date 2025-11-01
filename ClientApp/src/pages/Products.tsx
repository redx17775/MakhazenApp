// src/pages/Products.tsx
import { Edit, Trash2 } from "lucide-react";

type Product = {
  id: number;
  name: string;
  category: string;
  price: number;
  stock: number;
  image: string;
};

const products: Product[] = [
  {
    id: 1,
    name: "Wireless Headphones",
    category: "Electronics",
    price: 99,
    stock: 25,
    image: "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=100&q=60",
  },
  {
    id: 2,
    name: "Leather Backpack",
    category: "Bags",
    price: 79,
    stock: 10,
    image: "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?auto=format&fit=crop&w=100&q=60",
  },
  {
    id: 3,
    name: "Smart Watch",
    category: "Wearables",
    price: 120,
    stock: 0,
    image: "https://images.unsplash.com/photo-1519744346363-611b54f68947?auto=format&fit=crop&w=100&q=60",
  },
];

export default function Products() {
  return (
    <div className="text-gray-800 space-y-6 p-6">
      <h1 className="text-2xl font-semibold">Products</h1>

      <div className="bg-white rounded-xl shadow p-5">
        <table className="w-full text-sm text-left">
          <thead>
            <tr className="border-b text-gray-600">
              <th className="py-2">Image</th>
              <th className="py-2">Name</th>
              <th className="py-2">Category</th>
              <th className="py-2">Price</th>
              <th className="py-2">Stock</th>
              <th className="py-2 text-right">Actions</th>
            </tr>
          </thead>
          <tbody>
            {products.map((p) => (
              <tr key={p.id} className="border-b hover:bg-gray-50">
                <td className="py-2">
                  <img
                    src={p.image}
                    alt={p.name}
                    className="w-12 h-12 rounded-lg object-cover"
                  />
                </td>
                <td className="py-2 font-medium">{p.name}</td>
                <td className="py-2">{p.category}</td>
                <td className="py-2">${p.price}</td>
                <td className="py-2">
                  {p.stock > 0 ? (
                    <span className="text-green-600 font-semibold">In Stock</span>
                  ) : (
                    <span className="text-red-600 font-semibold">Out of Stock</span>
                  )}
                </td>
                <td className="py-2 text-right">
                  <button className="p-2 text-blue-600 hover:text-blue-800">
                    <Edit size={16} />
                  </button>
                  <button className="p-2 text-red-600 hover:text-red-800">
                    <Trash2 size={16} />
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
