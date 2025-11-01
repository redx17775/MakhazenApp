export default function StoresList() {
  const stores = [
    { name: "Manchester, UK", employees: 23, items: 308, orders: 2 },
    { name: "Yorkshire, UK", employees: 11, items: 291, orders: 15 },
    { name: "Hull, UK", employees: 5, items: 41, orders: 10 },
    { name: "Leicester, UK", employees: 16, items: 261, orders: 8 },
  ];

  return (
    <div className="bg-white p-4 rounded-2xl shadow flex flex-col gap-2">
      <div className="flex justify-between items-center mb-2">
        <h2 className="font-semibold">Stores list</h2>
        <button className="text-blue-500 text-sm">View all</button>
      </div>
      <table className="w-full text-sm">
        <tbody>
          {stores.map((s) => (
            <tr key={s.name} className="border-b last:border-0">
              <td>{s.name}</td>
              <td>{s.employees} employees</td>
              <td>{s.items} items</td>
              <td>{s.orders} orders</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
