import React, { useState } from "react";

const AddProduct: React.FC = () => {
  const [form, setForm] = useState({
    name: "",
    itemCode: "",
    description: "",
    stock: "",
    store: "",
    category: "",
    price: "",
    photo: "",
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement>) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    console.log("Form data:", form);
    alert("Product saved!");
  };

  return (
    <div className="p-6">
      <h1 className="text-2xl font-semibold mb-6">Add Product</h1>
      <form onSubmit={handleSubmit} className="grid grid-cols-2 gap-6">
        <div>
          <label className="block mb-2">Name*</label>
          <input name="name" value={form.name} onChange={handleChange} className="w-full border p-2 rounded-md" />
        </div>
        <div>
          <label className="block mb-2">Item code*</label>
          <input name="itemCode" value={form.itemCode} onChange={handleChange} className="w-full border p-2 rounded-md" />
        </div>
        <div className="col-span-2">
          <label className="block mb-2">Description</label>
          <textarea name="description" value={form.description} onChange={handleChange} className="w-full border p-2 rounded-md" />
        </div>
        <div>
          <label className="block mb-2">Stock size*</label>
          <input name="stock" value={form.stock} onChange={handleChange} className="w-full border p-2 rounded-md" />
        </div>
        <div>
          <label className="block mb-2">Stores availability*</label>
          <select name="store" value={form.store} onChange={handleChange} className="w-full border p-2 rounded-md">
            <option value="">Select</option>
            <option value="1">1 store</option>
            <option value="2">2 stores</option>
          </select>
        </div>
        <div>
          <label className="block mb-2">Category*</label>
          <select name="category" value={form.category} onChange={handleChange} className="w-full border p-2 rounded-md">
            <option value="">Select</option>
            <option value="T-Shirts">T-Shirts</option>
            <option value="Jeans">Jeans</option>
          </select>
        </div>
        <div>
          <label className="block mb-2">Price*</label>
          <input name="price" value={form.price} onChange={handleChange} className="w-full border p-2 rounded-md" />
        </div>
        <div className="col-span-2">
          <button type="submit" className="w-full bg-blue-600 text-white py-2 rounded-md hover:bg-blue-700">
            Save Product
          </button>
        </div>
      </form>
    </div>
  );
};

export default AddProduct;
