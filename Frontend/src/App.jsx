import {BrowserRouter,Routes,Route} from 'react-router-dom'
import Home from './Routes/homepage/home'
import ChooseCreateAcc from './Routes/ChooseCreateAcc'
import SignUpAsUser from './Routes/sign_up/SignUpAsUser'
import SignUpAsContractor from './Routes/sign_up/SignUpAsContractor'
import SignUpAsCompany from './Routes/sign_up/SignUpAsCompany'
import SignInAsUser from './Routes/sign_in/SignInAsUser'
import UDashboard from './Routes/user/user_dashboard'
// import ContDashboard from './Routes/contractor/contdashboard'
// import ContProfile from './Routes/contractor/cont_profile'
import CreateReport from './Routes/user/create_report'
import MyReports from './Routes/user/my_reports'
import Trending from './Routes/user/trending'
import Company from './Routes/company/Company'
import EditReport from './Routes/user/EditReport'
import Layout from '../src/components/cont_dashboard/Layout'
import ContReports from '../src/Routes/contractor/ContReports'
import ContProfile from '../src/Routes/contractor/ContProfile'
import ContTransaction from '../src/Routes/contractor/ContTransaction'


function App() {
  return (
    <>
      <BrowserRouter>
        <Routes>
         <Route index path="/" element={<Home/>} />
         <Route path="choosecreate" element={<ChooseCreateAcc/>} />
         <Route path="signupasuser" element={<SignUpAsUser/>} />
         <Route path="signupascontractor" element={<SignUpAsContractor/>} />
         <Route path="signupascompany" element={<SignUpAsCompany/>} />
         <Route path="signinasuser" element={<SignInAsUser/>} />
         <Route path="udashboard" element={<UDashboard/>} />
         {/* <Route path="contprofile" element={<ContProfile/>} /> */}
         <Route path="createreport" element={<CreateReport/>} />
         <Route path="reports" element={<MyReports/>} />
         <Route path="trending" element={<Trending/>} />
         <Route path="editreport/*" element={<EditReport/>} />
         <Route path='Company/*' element={<Company/>}/>

         <Route path="contdashboard" element={<Layout/>} >
           <Route path="GetReportById" element={<ContReports/>}/>
           <Route path="profile" element={<ContProfile/>} />
           <Route path="Transaction" element={<ContTransaction/>}/>
          </Route>

         <Route path="contdashboard/Logout" element={<Home/>}/>
         {/* <Route path="contdashboard/Logout/choose" element={<ChooseAccount/>}/> */}
         <Route path="contdashboard/Logout/choose/choosecreate" element={<ChooseCreateAcc/>}/>
         <Route path='contdashboard/Logout/choosecreate' element={<ChooseCreateAcc/>}/>

        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
