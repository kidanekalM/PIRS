import { useEffect, useState } from "react";
import Box from '@mui/material/Box'
import ReportCard from "./ReportCard/ReportCard";
import UNav from "../../components/user_dashboard/user_nav";


export default function Reports(companyId="1", status="0"){
    const [reports,setReports] = useState([]);
    useEffect(() => {
        fetch(`https://localhost:7077/Report`)
          .then(response => response.json())
          .then(data => setReports(data));
      }, []);
    
    return<>
    <UNav/>
    <Box display={"flex"} flexDirection='column' width={'90%'} gap='1.5rem' paddingTop={'100px'} paddingBottom={'50px'} className="report mx-5">

    {reports.map((r)=>{return <ReportCard report={r} appUserId={companyId} role="User" onDeleteClick={()=> {onDeleteClick(r) }} onEditCLick={()=>{onEditClick(r)}}/>})}
    </Box>
    </>
}
const onDeleteClick = (r) => {
  fetch(`https://localhost:7077/Report?id=${r.reportId}`,{
    method : 'DELETE',
    headers: {
      'Content-Type': 'application/json'      
    },
  })
  .then(() =>{
    alert("Report deleted successfully...");
    window.location.href = "./reports";
  })
  .catch(error => {
    // Handle error, e.g., show an error message
    console.error('Error deleting report:', error);
  });
};

const onEditClick = (r) => {
  window.location.href = `./editreport/${r.reportId}`;
};

