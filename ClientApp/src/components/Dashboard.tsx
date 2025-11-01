import SalesChart from "./SalesChart";
import TopCategories from "./TopCategories";
import StockNumbers from "./StockNumbers";
import StoresList from "./StoresList";
import Requests from "./Requests";

export default function Dashboard() {
  return (
    <div className="p-6 overflow-y-auto">
      <h1 className="text-xl font-semibold mb-4">Recent activity</h1>

      <div className="grid grid-cols-3 gap-6 mb-6">
        <SalesChart />
        <TopCategories />
      </div>

      <div className="grid grid-cols-3 gap-6">
        <StockNumbers />
        <StoresList />
      </div>

      <Requests />
    </div>
  );
}
