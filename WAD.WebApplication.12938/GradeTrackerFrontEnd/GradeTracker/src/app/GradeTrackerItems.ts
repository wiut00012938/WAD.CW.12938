export interface Teacher{
  id: number,
  teacherBackground: string,
  user: {
    id: number,
    firstName: string,
    lastName: string,
    profileImage: string
  }
}
export interface Student{
  id: number,
  enrolledModulesNum: number,
  user: {
    id: number,
    firstName: string,
    lastName: string,
    profileImage: string
  }
}
export interface Module{
  moduleId: number,
  moduleName: string,
  moduleDescription: string
}
export interface Assignment{
    assignmentId: number,
    assignmentName: string,
    assignmentDescription: string,
    createdDate: Date
}
