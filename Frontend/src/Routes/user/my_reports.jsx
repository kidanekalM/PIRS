import { useEffect, useState } from "react";
import Box from '@mui/material/Box'
import ReportCard from "./ReportCard/ReportCard";
import UNav from "../../components/user_dashboard/user_nav";


export default function Reports(companyId, status="0"){

  const [coord,setCoord] = useState( {
    latitude: 0.0,
    longitude: 0.1,
    altitude: 0.0,
    accuracy: 0.2,
    altitudeAccuracy: 0.0,
    heading: 0.0,
    speed: 0.0
  })

    const [reports,setReports] = useState([]);
    useEffect(() => {
      navigator.geolocation.getCurrentPosition((pos)=>{
        setCoord(pos.coords)
        fetch(`https://localhost:7077/Report/Sort?GeoCoordinate.Latitude=${pos.coords.latitude}&GeoCoordinate.Longitude=${pos.coords.longitude}&GeoCoordinate.Altitude=${pos.coords.altitude || 0}&GeoCoordinate.HorizontalAccuracy=${pos.coords.accuracy || 0}&GeoCoordinate.VerticalAccuracy=${pos.coords.altitudeAccuracy || 0}&GeoCoordinate.Speed=${pos.coords.speed || 0}&GeoCoordinate.Course=${pos.coords.heading || 0}&GeoCoordinate.IsUnknown=true&Status=${0}`)
          .then(response => response.json())
          .then(data => setReports(data));
      },(err)=>console.log(err))
      }, []);
    
    return<>
    <UNav/>
    <Box display={"flex"} flexDirection='column' width={'90%'} gap='1.5rem' paddingTop={'100px'} paddingBottom={'50px'} className="report mx-5">

    {reports.map((r)=>{return <ReportCard coord={coord} report={r} appUserId={companyId} role="User" onDeleteClick={()=> {onDeleteClick(r) }} onEditCLick={()=>{onEditClick(r)}}/>})}
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

