import { useState } from "react";

export default function AddProduct() {
  const [form, setForm] = useState({
    name: "",
    itemCode: "",
    description: "",
    stockSize: "",
    store: "",
    category: "",
    price: "",
    photo: "",
  });

  const [errors, setErrors] = useState<{ [key: string]: string }>({});

  // ✅ Validation logic
  const validate = () => {
    const newErrors: { [key: string]: string } = {};

    if (!form.name.trim()) newErrors.name = "Name is required";
    if (!form.itemCode.trim()) newErrors.itemCode = "Item Code is required";
    if (!form.stockSize) newErrors.stockSize = "Stock size is required";
    else if (Number(form.stockSize) <= 0)
      newErrors.stockSize = "Stock size must be greater than 0";
    if (!form.store) newErrors.store = "Select a store";
    if (!form.category) newErrors.category = "Select a category";
    if (!form.price) newErrors.price = "Price is required";
    else if (Number(form.price) <= 0)
      newErrors.price = "Price must be greater than 0";

    return newErrors;
  };

  // ✅ Handle field change
  const handleChange = (
    e: React.ChangeEvent<
      HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement
    >
  ) => {
    const { name, value } = e.target;
    setForm({ ...form, [name]: value });

    // live remove errors when typing
    if (errors[name]) {
      setErrors({ ...errors, [name]: "" });
    }
  };

  // ✅ Submit handler
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    const validationErrors = validate();

    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors);
      alert("❌ Please fix the errors before saving.");
      return;
    }

    alert("✅ Product saved:\n" + JSON.stringify(form, null, 2));
  };

  return (
    <div className="p-6">
      <h1 className="text-2xl font-semibold mb-6">Add Product</h1>
      <form
        onSubmit={handleSubmit}
        className="grid grid-cols-2 gap-6 bg-white p-6 rounded-xl shadow-sm border"
      >
        {/* Name */}
        <div>
          <label className="block mb-1 font-medium">Name*</label>
          <input
            type="text"
            name="name"
            value={form.name}
            onChange={handleChange}
            className={`w-full border rounded-lg p-2 ${
              errors.name ? "border-red-500" : ""
            }`}
          />
          {errors.name && <p className="text-red-500 text-sm">{errors.name}</p>}
        </div>

        {/* Item Code */}
        <div>
          <label className="block mb-1 font-medium">Item Code*</label>
          <input
            type="text"
            name="itemCode"
            value={form.itemCode}
            onChange={handleChange}
            className={`w-full border rounded-lg p-2 ${
              errors.itemCode ? "border-red-500" : ""
            }`}
          />
          {errors.itemCode && (
            <p className="text-red-500 text-sm">{errors.itemCode}</p>
          )}
        </div>

        {/* Description */}
        <div className="col-span-2">
          <label className="block mb-1 font-medium">Description</label>
          <textarea
            name="description"
            value={form.description}
            onChange={handleChange}
            className="w-full border rounded-lg p-2"
            rows={3}
          />
        </div>

        {/* Stock */}
        <div>
          <label className="block mb-1 font-medium">Stock Size*</label>
          <input
            type="number"
            name="stockSize"
            value={form.stockSize}
            onChange={handleChange}
            className={`w-full border rounded-lg p-2 ${
              errors.stockSize ? "border-red-500" : ""
            }`}
          />
          {errors.stockSize && (
            <p className="text-red-500 text-sm">{errors.stockSize}</p>
          )}
        </div>

        {/* Store */}
        <div>
          <label className="block mb-1 font-medium">Store Availability*</label>
          <select
            name="store"
            value={form.store}
            onChange={handleChange}
            className={`w-full border rounded-lg p-2 ${
              errors.store ? "border-red-500" : ""
            }`}
          >
            <option value="">Select store</option>
            <option value="Main">Main</option>
            <option value="Branch">Branch</option>
          </select>
          {errors.store && (
            <p className="text-red-500 text-sm">{errors.store}</p>
          )}
        </div>

        {/* Category */}
        <div>
          <label className="block mb-1 font-medium">Category*</label>
          <select
            name="category"
            value={form.category}
            onChange={handleChange}
            className={`w-full border rounded-lg p-2 ${
              errors.category ? "border-red-500" : ""
            }`}
          >
            <option value="">Select category</option>
            <option value="Bottoms">Bottoms</option>
            <option value="Tops">Tops</option>
            <option value="Accessories">Accessories</option>
          </select>
          {errors.category && (
            <p className="text-red-500 text-sm">{errors.category}</p>
          )}
        </div>

        {/* Price */}
        <div>
          <label className="block mb-1 font-medium">Price*</label>
          <input
            type="number"
            name="price"
            value={form.price}
            onChange={handleChange}
            className={`w-full border rounded-lg p-2 ${
              errors.price ? "border-red-500" : ""
            }`}
          />
          {errors.price && (
            <p className="text-red-500 text-sm">{errors.price}</p>
          )}
        </div>

        {/* Photo */}
        <div className="col-span-2">
          <label className="block mb-1 font-medium">Product Photo</label>
          <input
            type="file"
            onChange={(e) => {
              const file = e.target.files?.[0];
              if (file) setForm({ ...form, photo: URL.createObjectURL(file) });
            }}
            className="w-full border rounded-lg p-2"
          />
          {form.photo && (
            <img
              src={form.photo}
              alt="Preview"
              className="mt-2 w-24 h-24 object-cover rounded-lg border"
            />
          )}
        </div>

        {/* Submit */}
        <div className="col-span-2 text-center">
          <button
            type="submit"
            className="bg-blue-600 hover:bg-blue-700 text-white px-8 py-2 rounded-lg"
          >
            Save Product
          </button>
        </div>
      </form>
    </div>
  );
}
