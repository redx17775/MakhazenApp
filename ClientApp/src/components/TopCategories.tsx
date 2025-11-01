export default function TopCategories() {
  const images = [
    "/img1.jpg", "/img2.jpg", "/img3.jpg", "/img4.jpg",
    "/img5.jpg", "/img6.jpg", "/img7.jpg", "/img8.jpg"
  ];

  return (
    <div className="bg-white p-4 rounded-2xl shadow flex flex-col">
      <div className="flex justify-between items-center mb-3">
        <h2 className="font-semibold">Top item categories</h2>
        <button className="text-blue-500 text-sm">View all</button>
      </div>
      <div className="flex gap-2 overflow-x-auto">
        {images.map((src, i) => (
          <img key={i} src={src} alt="Category" className="w-20 h-20 rounded-lg object-cover" />
        ))}
      </div>
    </div>
  );
}
