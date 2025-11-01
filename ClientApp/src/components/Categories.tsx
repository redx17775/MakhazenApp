import React from "react";

interface Category {
  id: number;
  name: string;
  items: number;
  image: string;
}

const categories: Category[] = [
  { id: 1, name: "Bottoms", items: 49, image: "/images/bottoms.jpg" },
  { id: 2, name: "Tops", items: 7, image: "/images/tops.jpg" },
  { id: 3, name: "T-Shirts", items: 13, image: "/images/tshirt.jpg" },
  { id: 4, name: "Accessories", items: 63, image: "/images/accessories.jpg" },
  { id: 5, name: "Coats", items: 23, image: "/images/coats.jpg" },
  { id: 6, name: "Jeans", items: 11, image: "/images/jeans.jpg" },
];

const Categories: React.FC = () => {
  return (
    <div className="p-6">
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-semibold">Categories</h1>
        <button className="bg-blue-600 text-white px-4 py-2 rounded-md hover:bg-blue-700">
          + Add category
        </button>
      </div>
      <div className="space-y-4">
        {categories.map((cat) => (
          <div
            key={cat.id}
            className="flex items-center justify-between bg-white shadow p-4 rounded-lg"
          >
            <div className="flex items-center space-x-4">
              <img
                src={cat.image}
                alt={cat.name}
                className="w-12 h-12 rounded-md object-cover"
              />
              <div>
                <h2 className="font-semibold">{cat.name}</h2>
                <p className="text-gray-500 text-sm">{cat.items} items</p>
              </div>
            </div>
            <button className="text-gray-500 hover:text-blue-600">
              →
            </button>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Categories;
