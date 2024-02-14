import { useEffect, useState } from "react";
import Box from '@mui/material/Box'
import ReportCard from "./ReportCard/ReportCard";
import UNav from "../../components/user_dashboard/user_nav";

export default function Reports(companyId="1", status="0"){
    const [reports,setReports] = useState([]);
    useEffect(() => {
        fetch(`${apiKey}/Report`)
          .then(response => response.json())
          .then(data => setReports(data));
      }, []);
    
    return<>
    <UNav/>
    <Box display={"flex"} flexDirection='column' width={'90%'} gap='1.5rem' paddingTop={'100px'} paddingBottom={'50px'} className="report mx-5">

    {reports.map((r)=>{return <ReportCard report={r} appUserId={companyId} role="Company" onApproveClick={(e)=>{console.log(e)}} onRejectClick={()=>{console.log(r)}}/>})}
    </Box>
    </>
}