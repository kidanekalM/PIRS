import {BrowserRouter,Routes,Route} from 'react-router-dom'
import Home from './Routes/homepage/home'
import ChooseAccount from './Routes/ChooseAccount'
import ChooseCreateAcc from './Routes/ChooseCreateAcc'
import SignUpAsUser from './Routes/sign_up/SignUpAsUser'
import SignUpAsContractor from './Routes/sign_up/SignUpAsContractor'
import SignUpAsCompany from './Routes/sign_up/SignUpAsCompany'
import SignInAsUser from './Routes/sign_in/SignInAsUser'
import SignInAsContractor from './Routes/sign_in/SignInAsContractor'
import SignInAsCompany from './Routes/sign_in/SignInAsCompany'
import UDashboard from './Routes/user/user_dashboard'
import ContDashboard from './Routes/contractor/contdashboard'
import UProfile from './Routes/user/user_profile'
import ContProfile from './Routes/contractor/cont_profile'
import CreateReport from './Routes/user/create_report'
import MyReports from './Routes/user/my_reports'
import Trending from './Routes/user/trending'

function App() {
  return (
    <>
      <BrowserRouter>
        <Routes>
         <Route index path="/" element={<Home/>} />
         <Route path="choose" element={<ChooseAccount/>} />
         <Route path="choosecreate" element={<ChooseCreateAcc/>} />
         <Route path="signupasuser" element={<SignUpAsUser/>} />
         <Route path="signupascontractor" element={<SignUpAsContractor/>} />
         <Route path="signupascompany" element={<SignUpAsCompany/>} />
         <Route path="signinasuser" element={<SignInAsUser/>} />
         <Route path="signinascontractor" element={<SignInAsContractor/>} />
         <Route path="signinascompany" element={<SignInAsCompany/>} />
         <Route path="udashboard" element={<UDashboard/>} />
         <Route path="contdashboard" element={<ContDashboard/>} />
         <Route path="uprofile" element={<UProfile/>} />
         <Route path="contprofile" element={<ContProfile/>} />
         <Route path="createreport" element={<CreateReport/>} />
         <Route path="reports" element={<MyReports/>} />
         <Route path="trending" element={<Trending/>} />
         
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
