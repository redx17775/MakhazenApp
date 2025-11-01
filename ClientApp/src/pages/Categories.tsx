import { useState } from "react";
import { Plus } from "lucide-react";

export default function Categories() {
  const [categories] = useState([
    { id: 1, name: "Bottoms", items: 49, image: "https://via.placeholder.com/50" },
    { id: 2, name: "Tops", items: 7, image: "https://via.placeholder.com/50" },
    { id: 3, name: "T-Shirts", items: 13, image: "https://via.placeholder.com/50" },
    { id: 4, name: "Accessories", items: 63, image: "https://via.placeholder.com/50" },
    { id: 5, name: "Coats", items: 23, image: "https://via.placeholder.com/50" },
    { id: 6, name: "Jeans", items: 11, image: "https://via.placeholder.com/50" },
  ]);

  return (
    <div className="p-6">
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-semibold">Categories</h1>
        <button className="bg-blue-600 hover:bg-blue-700 text-white px-4 py-2 rounded-lg flex items-center gap-2">
          <Plus size={18} /> Add category
        </button>
      </div>
      <p className="text-sm text-gray-500 mb-4">
        Last update: {new Date().toLocaleString()}
      </p>

      <div className="space-y-3">
        {categories.map((cat) => (
          <div
            key={cat.id}
            className="flex justify-between items-center bg-white rounded-xl shadow-sm border p-3 hover:shadow-md transition"
          >
            <div className="flex items-center gap-4">
              <img
                src={cat.image}
                alt={cat.name}
                className="w-12 h-12 rounded-lg object-cover"
              />
              <div>
                <h2 className="font-semibold">{cat.name}</h2>
                <p className="text-sm text-gray-500">{cat.items} items</p>
              </div>
            </div>
            <button className="text-gray-400 hover:text-gray-600 text-xl">›</button>
          </div>
        ))}
      </div>
    </div>
  );
}
